using AutoMapper;
using BhdBankClone.Core.Application.DTOs.BankAccounts;
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
    public int AccountTypeId { get; set; }

    public required int ClientId { get; set; }

    public int? DebitCardId { get; set; }

    public required decimal CurrentBalance { get; set; }
  }

  public class CreateBankAccountCommandHandler: IRequestHandler<CreateBankAccountCommand, Response<BankAccountDTO>>
  {
    private readonly IGenericRepository<Account> _repository;
    private readonly IGenericRepository<DebitCard> _debitCardRepository;
    private readonly IGenericRepository<AccountType> _accountTypeRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateBankAccountCommand> _validator;

    public CreateBankAccountCommandHandler(IGenericRepository<Account> repository, IMapper mapper, IValidator<CreateBankAccountCommand> validator, IClientRepository clientRepository, IGenericRepository<DebitCard> debitCardRepository, IGenericRepository<AccountType> accountTypeRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
      _debitCardRepository = debitCardRepository;
      _accountTypeRepository = accountTypeRepository;
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

      if (req.DebitCardId != null)
      {
        var debitCardExist = await _debitCardRepository.GetByIdAsync(req.DebitCardId.Value);

        if (debitCardExist == null) throw new ApiException($"Debit card with id: {req.DebitCardId} does not exist.");
      }

      var accountTypeIsValid = await _accountTypeRepository.GetByIdAsync(req.AccountTypeId);

      if (accountTypeIsValid == null) throw new ApiException($"Account type with id: {req.AccountTypeId} does not exist.");

      Account bankAccount = new()
      {
        IsActive = true,
        IsPrimary = true, //TODO: Check if client already has a bank account to set it as primary to true or false
        AccountNumber = GenerateRandom.GenerateRandomNumber(11),
        AccountTypeId = req.AccountTypeId,
        ClientId = req.ClientId,
        DebitCardId = req.DebitCardId,
        CurrentBalance = req.CurrentBalance
      };

      var createdBankAccount = await _repository.AddAsync(bankAccount);
      
      return _mapper.Map<BankAccountDTO>(createdBankAccount);
    }
  }
}
