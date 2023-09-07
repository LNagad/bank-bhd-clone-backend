using AutoMapper;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Helpers;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Commands
{
  public class CreateDebitCardCommand : IRequest<Response<DebitCardDTO>>
  {
    public int ClientId { get; set; }
    public int AccountId { get; set; }
  }
  public class CreateDebitCardCommandHandler : IRequestHandler<CreateDebitCardCommand, Response<DebitCardDTO>>
  {
    private readonly IGenericRepository<DebitCard> _DebitCardRepository;
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IGenericRepository<Account> _accountRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateDebitCardCommand> _validator;

    public CreateDebitCardCommandHandler(IGenericRepository<DebitCard> DebitCardRepository, IMapper mapper, IValidator<CreateDebitCardCommand> validator, IClientRepository clientRepository, IGenericRepository<Product> productRepository, IGenericRepository<Account> accountRepository)
    {
      _DebitCardRepository = DebitCardRepository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
      _productRepository = productRepository;
      _accountRepository = accountRepository;
    }

    public async Task<Response<DebitCardDTO>> Handle(CreateDebitCardCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<DebitCardDTO>() { Data = await CreateDebitCardAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<DebitCardDTO> CreateDebitCardAsync(CreateDebitCardCommand req)
    {
      var clientExist = await _clientRepository.GetByIdAsync(req.ClientId);

      if (clientExist == null) throw new ApiException($"Client with id: {req.ClientId} does not exist.");

      var accountExist = await _accountRepository.GetByIdAsync(req.AccountId);

      if (accountExist == null) throw new ApiException($"Account with id: {req.AccountId} does not exist.");

      var hasAnyDebitCard = _DebitCardRepository.GetQueryable()
        .Any(x => x.ClientId == req.ClientId && x.AccountId == req.AccountId);

      DebitCard debitCard = new()
      {
        CardNumber = GenerateRandom.GenerateRandomNumber(16),
        CardCvv = GenerateRandom.GenerateRandomNumber(3),
        CardExpiryDate = DateTime.Now.AddYears(5),
        ClientId = req.ClientId,
        AccountId = req.AccountId,
        IsActive = true,
        IsPrimary = !hasAnyDebitCard, //Check if client already has a debit card to set it as primary to true or false
      };

      await _DebitCardRepository.AddAsync(debitCard);
      
      Product product = new()
      {
        ClientId = req.ClientId,
        AccountId = req.AccountId,
        DebitCardId = debitCard.Id,
        IsDebitCard = true,
        ProductTypeId = (int)EProducts.TARJETA_DEBITO
      };
      await _productRepository.AddAsync(product);

      //Update debit card with product id
      debitCard.ProductId = product.Id;
      await _DebitCardRepository.Update(debitCard);

      accountExist.DebitCardId = debitCard.Id;
      await _accountRepository.Update(accountExist);

      return _mapper.Map<DebitCardDTO>(debitCard);
    }
  }
}
