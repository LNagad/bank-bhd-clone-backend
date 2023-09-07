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
using System.Net;

namespace BhdBankClone.Core.Application.Features.Products.Commands
{
  public class CreateFavoriteTransactionCommand : IRequest<Response<FavoriteTransactionDTO>>
  {
    public int TransactionTypeId { get; set; }
    public int ClientId { get; set; }
    public decimal Amount { get; set; }

    public int? SourceAccountId { get; set; }
    public int? SourceCreditCardId { get; set; }

    public int? DestinationCreditCardId { get; set; }
    public int? DestinationAccountId { get; set; }
    public int? DestinationLoanId { get; set; }

  }
  internal class CreateFavoriteTransactionCommandHandler : IRequestHandler<CreateFavoriteTransactionCommand, Response<FavoriteTransactionDTO>>
  {
    private readonly IGenericRepository<FavoriteTransaction> _favoriteTransactionRepository;
    private readonly IGenericRepository<TransactionType> _transactionTypeRepository;
    private readonly IGenericRepository<Account> _accountRepository;
    private readonly IGenericRepository<CreditCard> _creditCardRepository;
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly IValidator<CreateFavoriteTransactionCommand> _validator;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;

    public CreateFavoriteTransactionCommandHandler(
      IGenericRepository<FavoriteTransaction> favoriteTransactionRepository,
      IGenericRepository<TransactionType> transactionTypeRepository,
      IGenericRepository<Account> accountRepository, 
      IGenericRepository<CreditCard> creditCardRepository, 
      IGenericRepository<Loan> loanRepository, 
      IClientRepository clientRepository,
      IValidator<CreateFavoriteTransactionCommand> validator, 
      IMapper mapper)
    {
      _favoriteTransactionRepository = favoriteTransactionRepository;
      _transactionTypeRepository = transactionTypeRepository;
      _validator = validator;
      _mapper = mapper;
      _accountRepository = accountRepository;
      _creditCardRepository = creditCardRepository;
      _loanRepository = loanRepository;
      _clientRepository = clientRepository;
    }

    public async Task<Response<FavoriteTransactionDTO>> Handle(CreateFavoriteTransactionCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<FavoriteTransactionDTO>() { Data = await CreateTransactionAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<FavoriteTransactionDTO> CreateTransactionAsync(CreateFavoriteTransactionCommand req)
    {
      await ValidateEntitiesExistenceAsync(req);

      var transaction = _mapper.Map<FavoriteTransaction>(req);

      transaction.TransactionTypeId = ValidateTransactionType(req);

      var resp = await _favoriteTransactionRepository.AddAsync(transaction);

      return _mapper.Map<FavoriteTransactionDTO>(resp);
    }

    #region Private Methods

    private async Task ValidateEntitiesExistenceAsync(CreateFavoriteTransactionCommand req)
    {
      await ValidateEntityExistenceAsync(req.SourceCreditCardId, _creditCardRepository, "Credit card not found");
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
          throw new ApiException(errorMessage, (int)HttpStatusCode.NotFound);
        }
      }
    }

    private int ValidateTransactionType(CreateFavoriteTransactionCommand req)
    {
      switch (req.TransactionTypeId)
      {
        case (int)ETransactions.TRANSFERENCIA:
        case (int)ETransactions.RETIRO:
        case (int)ETransactions.DEPOSITO:
        case (int)ETransactions.PAGO_TARJETA_CREDITO:
        case (int)ETransactions.PAGO_PRESTAMO:
          var tType = _transactionTypeRepository.GetQueryable().FirstOrDefault(pt => pt.Description == ((ETransactions)req.TransactionTypeId).ToString());

          if (tType == null) throw new ApiException("Transaction type not found", 404);

          return tType.Id;
        default:
          throw new ApiException("Invalid Transaction type", 400);
      }
    }

    #endregion
  }
}
