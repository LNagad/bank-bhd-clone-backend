using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using BhdBankClone.Core.Domain.Common;
using FluentValidation;
using MediatR;


namespace BhdBankClone.Core.Application.Features.Products.Commands
{
  public class CreateTransactionCommand : IRequest<Response<TransactionDTO>>
  {
    public int TransactionTypeId { get; set; }
    public int ClientId { get; set; }
    public decimal Amount { get; set; }

    public int? SourceAccountId { get; set; }
    public int? SourceCreditCardId { get; set; }
    public int? SourceDebitCardId { get; set; }
    public int? DestinationCreditCardId { get; set; }
    public int? DestinationAccountId { get; set; }
    public int? DestinationLoanId { get; set; }

  }
  internal class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Response<TransactionDTO>>
  {
    private readonly IGenericRepository<BankTransaction> _transactionRepository;
    private readonly IGenericRepository<TransactionType> _transactionTypeRepository;
    private readonly IGenericRepository<Account> _accountRepository;
    private readonly IGenericRepository<CreditCard> _creditCardRepository;
    private readonly IGenericRepository<DebitCard> _debitCardRepository;
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IValidator<CreateTransactionCommand> _validator;
    private readonly IMapper _mapper;

    public CreateTransactionCommandHandler(
      IGenericRepository<BankTransaction> transactionRepository,
      IGenericRepository<TransactionType> transactionTypeRepository,
      IGenericRepository<Account> accountRepository, 
      IGenericRepository<CreditCard> creditCardRepository, 
      IGenericRepository<DebitCard> debitCardRepository, 
      IGenericRepository<Loan> loanRepository, 
      IClientRepository clientRepository,
      IValidator<CreateTransactionCommand> validator, 
      IMapper mapper)
    {
      _transactionRepository = transactionRepository;
      _transactionTypeRepository = transactionTypeRepository;
      _validator = validator;
      _mapper = mapper;
      _accountRepository = accountRepository;
      _creditCardRepository = creditCardRepository;
      _debitCardRepository = debitCardRepository;
      _loanRepository = loanRepository;
      _clientRepository = clientRepository;
    }

    public async Task<Response<TransactionDTO>> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<TransactionDTO>() { Data = await CreateTransactionAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<TransactionDTO> CreateTransactionAsync(CreateTransactionCommand req)
    {
      await ValidateEntitiesExistenceAsync(req);

      var transaction = _mapper.Map<BankTransaction>(req);

      transaction.TransactionTypeId = ValidateTransactionType(req);
      transaction.TransactionTime = DateTime.UtcNow;
      //TODO : Validate destination and source transaction types are not same id's

      await MangeTransactionDestination(req);

      var resp = await _transactionRepository.AddAsync(transaction);

      return _mapper.Map<TransactionDTO>(resp);
    }

    #region Private Methods

    private async Task ValidateEntitiesExistenceAsync(CreateTransactionCommand req)
    {
      await ValidateEntityExistenceAsync(req.SourceCreditCardId, _creditCardRepository, "Credit card not found");
      await ValidateEntityExistenceAsync(req.SourceDebitCardId, _debitCardRepository, "Debit card not found");
      await ValidateEntityExistenceAsync(req.SourceAccountId, _accountRepository, "Account not found");
      await ValidateEntityExistenceAsync(req.DestinationAccountId, _accountRepository, "Account not found");
      await ValidateEntityExistenceAsync(req.DestinationCreditCardId, _creditCardRepository, "Credit card not found");
      await ValidateEntityExistenceAsync(req.DestinationLoanId, _loanRepository, "Loan not found");
      await ValidateEntityExistenceAsync(req.ClientId, _clientRepository, "Client not found");
    }

    private async Task ValidateEntityExistenceAsync<T>(int? entityId, IGenericRepository<T> repository, string errorMessage) where T : AuditableBaseEntity
    {
      if (entityId != null && entityId > 0)
      {
        var entity = await repository.GetByIdAsync(entityId.Value);
        if (entity == null)
        {
          throw new ApiException(errorMessage, 404);
        }
      }
    }

    private int ValidateTransactionType(CreateTransactionCommand req)
    {
      switch (req.TransactionTypeId)
      {
        case (int)ETransactions.TRANSFERENCIA:
        case (int)ETransactions.RETIRO:
        case (int)ETransactions.DEPOSITO:
        case (int)ETransactions.PAGO_TARJETA_CREDITO:
        case (int)ETransactions.PAGO_PRESTAMO:
          var tType = _transactionTypeRepository.GetQueryable().FirstOrDefault(pt => pt.Description == ((ETransactions)req.TransactionTypeId).ToString());

          if (tType == null) throw new ApiException("Product type not found", 404);

          return tType.Id;
        default:
          throw new ApiException("Invalid product type", 400);
      }
    }

    private async Task<bool> MangeTransactionDestination(CreateTransactionCommand transaction)
    {
      #region account to account

      if ((transaction.SourceAccountId != null && transaction.SourceAccountId > 0) && (transaction.DestinationAccountId != null && transaction.DestinationAccountId > 0) )
      {
        var sourceAccount = await _accountRepository.GetByIdAsync(transaction.SourceAccountId.Value);

        if (sourceAccount!.CurrentBalance < transaction.Amount)
        {
          throw new ApiException("Insufficient funds", 400);
        }

        var destinationAccount = await _accountRepository.GetByIdAsync(transaction.DestinationAccountId.Value);

        destinationAccount!.CurrentBalance += transaction.Amount;

        sourceAccount.CurrentBalance -= transaction.Amount;

        await _accountRepository.Update(sourceAccount);
        await _accountRepository.Update(destinationAccount);
      }

      #endregion

      #region account to credit card

      if ((transaction.SourceAccountId != null && transaction.SourceAccountId > 0) && (transaction.DestinationCreditCardId != null && transaction.DestinationCreditCardId > 0) )
      {
        var sourceAccount = await _accountRepository.GetByIdAsync(transaction.SourceAccountId.Value);

        if (sourceAccount!.CurrentBalance < transaction.Amount) throw new ApiException("Insufficient funds", 400);

        var destinationCCard = await _creditCardRepository.GetByIdAsync(transaction.DestinationCreditCardId.Value);

        if (destinationCCard!.CreditCardDebt <= 0 || destinationCCard.CreditCardDebt == null) 
        { 
          throw new ApiException("Credit card debt is 0", 400);
        }

        decimal? CCDebt = destinationCCard.CreditCardDebt;

        //Check if the amount is greater than the debt to not have negative debt and negative balance
        //This also ensures that system is discounting the correct amount from the account
        if (transaction.Amount >= CCDebt )
        {
          destinationCCard.CreditCardDebt = 0;
          destinationCCard.CurrentBalance = destinationCCard.CreditLimit;   
          sourceAccount.CurrentBalance -= CCDebt;
        }
        else
        {
          destinationCCard.CreditCardDebt -= transaction.Amount;
          sourceAccount.CurrentBalance -= transaction.Amount;
        }

        await _accountRepository.Update(sourceAccount);
        await _creditCardRepository.Update(destinationCCard);
      }

      #endregion

      #region account to loan

      if ((transaction.SourceAccountId != null && transaction.SourceAccountId > 0) && (transaction.DestinationLoanId != null && transaction.DestinationLoanId > 0))
      {
        var sourceAccount = await _accountRepository.GetByIdAsync(transaction.SourceAccountId.Value);

        if (sourceAccount!.CurrentBalance < transaction.Amount) throw new ApiException("Insufficient funds", 400);

        var destinationLoan = await _loanRepository.GetByIdAsync(transaction.DestinationLoanId.Value);

        if (destinationLoan!.LoanBalance == null || destinationLoan.LoanBalance <= 0)
        {
          throw new ApiException("Loan Balance is 0", 400);
        }

        double? LoanDebt = destinationLoan.LoanBalance;

        //Check if the amount is greater than the debt to not have negative debt and negative balance
        //This also ensures that system is discounting the correct amount from the account
        if (transaction.Amount >= (decimal)LoanDebt)
        {
          destinationLoan.LoanBalance = 0;
          sourceAccount.CurrentBalance -= (decimal)LoanDebt;
        }
        else
        {
          destinationLoan.LoanBalance -= (double)transaction.Amount;
          sourceAccount.CurrentBalance -= transaction.Amount;
        }

        await _accountRepository.Update(sourceAccount);
        await _loanRepository.Update(destinationLoan);
      }

      #endregion

      #region credit card to account
      if 
      ( 
        (transaction.SourceCreditCardId != null && transaction.SourceCreditCardId > 0) 
        && (transaction.DestinationAccountId != null && transaction.DestinationAccountId > 0)
      )
      {
        var sourceCCard = await _creditCardRepository.GetByIdAsync(transaction.SourceCreditCardId.Value);

        if (sourceCCard!.CurrentBalance < transaction.Amount) throw new ApiException("Insufficient funds", 400);

        var destinationAccount = await _accountRepository.GetByIdAsync(transaction.DestinationAccountId.Value);

        destinationAccount!.CurrentBalance += transaction.Amount;

        sourceCCard.CurrentBalance -= transaction.Amount;

        await _accountRepository.Update(destinationAccount);
        await _creditCardRepository.Update(sourceCCard);
      }
      #endregion

      #region credit card to credit card

      if ((transaction.SourceCreditCardId != null && transaction.SourceCreditCardId > 0) && (transaction.DestinationCreditCardId != null && transaction.DestinationCreditCardId > 0))
      {
        var sourceCCard = await _creditCardRepository.GetByIdAsync(transaction.SourceCreditCardId.Value);

        if (sourceCCard!.CurrentBalance < transaction.Amount) throw new ApiException("Insufficient funds", 400);

        var destinationCCard = await _creditCardRepository.GetByIdAsync(transaction.DestinationCreditCardId.Value);

        if (destinationCCard!.CreditCardDebt <= 0 || destinationCCard.CreditCardDebt == null)
        {
          throw new ApiException("Credit card debt is 0", 400);
        }

        decimal? CCDebt = destinationCCard.CreditCardDebt;

        //Check if the amount is greater than the debt to not have negative debt and negative balance
        //This also ensures that system is discounting the correct amount from the account
        if (transaction.Amount >= CCDebt)
        {
          destinationCCard.CreditCardDebt = 0;
          destinationCCard.CurrentBalance = destinationCCard.CreditLimit;
          sourceCCard.CurrentBalance -= CCDebt;
        }
        else
        {
          destinationCCard.CreditCardDebt -= transaction.Amount;
          sourceCCard.CurrentBalance -= transaction.Amount;
        }

        await _creditCardRepository.Update(destinationCCard);
        await _creditCardRepository.Update(sourceCCard);
      }

      #endregion

      #region credit card to loan

      if ((transaction.SourceCreditCardId != null && transaction.SourceCreditCardId > 0) && (transaction.DestinationLoanId != null && transaction.DestinationLoanId > 0))
      {
        var sourceCCard = await _creditCardRepository.GetByIdAsync(transaction.SourceCreditCardId.Value);

        if (sourceCCard!.CurrentBalance < transaction.Amount) throw new ApiException("Insufficient funds", 400);

        var destinationLoan = await _loanRepository.GetByIdAsync(transaction.DestinationLoanId.Value);

        if (destinationLoan!.LoanBalance == null || destinationLoan.LoanBalance <= 0)
        {
          throw new ApiException("Loan Balance is 0", 400);
        }

        double? LoanDebt = destinationLoan.LoanBalance;

        //Check if the amount is greater than the debt to not have negative debt and negative balance
        //This also ensures that system is discounting the correct amount from the account
        if (transaction.Amount >= (decimal)LoanDebt)
        {
          destinationLoan.LoanBalance = 0;
          sourceCCard.CurrentBalance -= (decimal)LoanDebt;
        }
        else
        {
          destinationLoan.LoanBalance -= (double)transaction.Amount;
          sourceCCard.CurrentBalance -= transaction.Amount;
        }

        await _creditCardRepository.Update(sourceCCard);
        await _loanRepository.Update(destinationLoan);
      }

      #endregion

      return true;
    }


    #endregion
  }
}
