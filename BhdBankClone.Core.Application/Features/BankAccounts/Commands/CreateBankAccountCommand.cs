using AutoMapper;
using BhdBankClone.Core.Application.DTOs.BankAccounts;
using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Helpers;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.BankAccounts.Commands
{
  public class CreateBankAccountCommand: IRequest<Response<BankAccountDTO>>
  {
    //public int AccountTypeId { get; set; } // for now , we will only have one account type

    public required int ClientId { get; set; }

    public required decimal CurrentBalance { get; set; }
  }

  public class CreateBankAccountCommandHandler: IRequestHandler<CreateBankAccountCommand, Response<BankAccountDTO>>
  {
    private readonly IGenericRepository<Account> _repository;
    private readonly IGenericRepository<DebitCard> _debitCardRepository;
    private readonly IGenericRepository<AccountType> _accountTypeRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateBankAccountCommand> _validator;

    public CreateBankAccountCommandHandler(IGenericRepository<Account> repository, IMapper mapper, IValidator<CreateBankAccountCommand> validator, IClientRepository clientRepository, IGenericRepository<DebitCard> debitCardRepository, IGenericRepository<AccountType> accountTypeRepository, IGenericRepository<Product> productRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
      _debitCardRepository = debitCardRepository;
      _accountTypeRepository = accountTypeRepository;
      _productRepository = productRepository;
    }

    public async Task<Response<BankAccountDTO>> Handle(CreateBankAccountCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<BankAccountDTO>() { Data = await CreateBankAccount(request), Succeeded = true, Errors = null };
    }

    private async Task<BankAccountDTO> CreateBankAccount(CreateBankAccountCommand req)
    {
      var clientExist = await _clientRepository.GetByIdAsync(req.ClientId);

      if (clientExist == null) throw new ApiException($"Client with id: {req.ClientId} does not exist.");

      //if (req.DebitCardId != null)
      //{
      //  var debitCardExist = await _debitCardRepository.GetByIdAsync(req.DebitCardId.Value);

      //  if (debitCardExist == null) throw new ApiException($"Debit card with id: {req.DebitCardId} does not exist.");
      //}

      //var accountTypeIsValid = await _accountTypeRepository.GetByIdAsync(req.AccountTypeId);

      //if (accountTypeIsValid == null) throw new ApiException($"Account type with id: {req.AccountTypeId} does not exist.");

      var hasAnyBankAccount = _repository.GetQueryable().Any(account => account.ClientId == req.ClientId);

      Account bankAccount = new()
      {
        IsActive = true,
        IsPrimary = !hasAnyBankAccount, // Check if client already has a bank account to set it as primary to true or false
        AccountNumber = GenerateRandom.GenerateRandomNumber(11),
        AccountTypeId = (int)EAccounts.CUENTA_AHORROS,
        ClientId = req.ClientId,
        //DebitCardId = req.DebitCardId,
        CurrentBalance = req.CurrentBalance
      };

       await _repository.AddAsync(bankAccount);

      Product product = new()
      {
        ClientId = req.ClientId,
        AccountId = bankAccount.Id,
        IsAccount = true,
        ProductTypeId = (int)EProducts.CUENTA_AHORROS,
      };

      await _productRepository.AddAsync(product);

      bankAccount.ProductId = product.Id;

      await _repository.Update(bankAccount);

      return _mapper.Map<BankAccountDTO>(bankAccount);
    }
  }
}
