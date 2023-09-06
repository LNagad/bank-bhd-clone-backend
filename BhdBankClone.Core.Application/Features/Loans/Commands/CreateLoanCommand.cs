using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;
using System.Transactions;

namespace BhdBankClone.Core.Application.Features.Loans.Commands
{
  public class CreateLoanCommand : IRequest<Response<LoanDTO>>
  {
    public double LoanAmount { get; set; }

    public int ClientId { get; set; }

    public int AccountId { get; set; }
  }
  internal class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Response<LoanDTO>>
  {
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly IGenericRepository<Account> _accountRepository;
    private readonly IGenericRepository<BankTransaction> _transactionRepository;
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateLoanCommand> _validator;

    public CreateLoanCommandHandler(IGenericRepository<Loan> LoanRepository, IMapper mapper, IValidator<CreateLoanCommand> validator, IClientRepository clientRepository, IProductRepository productRepository, IGenericRepository<Account> accountRepository, IGenericRepository<BankTransaction> transactionRepository)
    {
      _loanRepository = LoanRepository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
      _productRepository = productRepository;
      _accountRepository = accountRepository;
      _transactionRepository = transactionRepository;
    }

    public async Task<Response<LoanDTO>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<LoanDTO>() { Data = await CreateLoanAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<LoanDTO> CreateLoanAsync(CreateLoanCommand req)
    {
      var clientExist = await _clientRepository.GetByIdAsync(req.ClientId);

      if (clientExist == null) throw new ApiException($"Client with id: {req.ClientId} does not exist.");

      var accountExist = await _accountRepository.GetByIdAsync(req.AccountId);

      if (accountExist == null) throw new ApiException($"Account with id: {req.AccountId} does not exist.");

      if (accountExist.ClientId != req.ClientId) throw new ApiException($"Account with id: {req.AccountId} does not belong to client with id: {req.ClientId}.");

      var loanEntity = _mapper.Map<Loan>(req);
      loanEntity.LoanBalance = req.LoanAmount;

      var Loan = await _loanRepository.AddAsync(loanEntity);

      var product = await _productRepository.AddAsync(new Product()
      {
        IsLoan = true,
        AccountId = req.AccountId,
        ClientId = req.ClientId,
        LoanId = Loan.Id,
        ProductTypeId = (int)EProducts.PRESTAMO 
      });

      Loan.ProductId = product.Id;

      await _loanRepository.Update(Loan);

      accountExist.CurrentBalance += (decimal)req.LoanAmount; //assign loan money to account

      await _accountRepository.Update(accountExist);

      //Create transaction

      var transaction = await _transactionRepository.AddAsync(new BankTransaction()
      {
        ClientId = req.ClientId,
        DestinationAccountId = req.AccountId,
        Amount = (decimal)req.LoanAmount,
        SourceLoanId = Loan.Id,
        TransactionTime = DateTime.UtcNow,
        TransactionTypeId = (int)ETransactions.PRESTAMO,
      });


      Loan.SourceTransactionId = transaction.Id;

      await _loanRepository.Update(Loan);


      return _mapper.Map<LoanDTO>(Loan);
    }
  }
}
