using AutoMapper;
using BhdBankClone.Core.Application.DTOs.CreditCards;
using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Helpers;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Commands
{
  public class CreateCreditCardCommand : IRequest<Response<CreditCardDTO>>
  {
    public required decimal CreditLimit { get; set; }
    public int ClientId { get; set; }

  }
  public class CreateCreditCardCommandHandler : IRequestHandler<CreateCreditCardCommand, Response<CreditCardDTO>>
  {
    private readonly IGenericRepository<CreditCard> _CreditCardRepository;
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCreditCardCommand> _validator;

    public CreateCreditCardCommandHandler(IGenericRepository<CreditCard> CreditCardRepository, IMapper mapper, IValidator<CreateCreditCardCommand> validator, IClientRepository clientRepository, IProductRepository productRepository)
    {
      _CreditCardRepository = CreditCardRepository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
      _productRepository = productRepository;
    }

    public async Task<Response<CreditCardDTO>> Handle(CreateCreditCardCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<CreditCardDTO>() { Data = await CreateCreditCardAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<CreditCardDTO> CreateCreditCardAsync(CreateCreditCardCommand req)
    {
      var clientExist = await _clientRepository.GetByIdAsync(req.ClientId);

      if (clientExist == null) throw new ApiException($"Client with id: {req.ClientId} does not exist.");

      var hasAnyDebitCard = _CreditCardRepository.GetQueryable()
      .Any(x => x.ClientId == req.ClientId);

      CreditCard creditCard = new()
      {
        CardNumber = GenerateRandom.GenerateRandomNumber(16),
        CardCvv = GenerateRandom.GenerateRandomNumber(3),
        CardExpiryDate = DateTime.Now.AddYears(5),
        ClientId = req.ClientId,
        CreditLimit = req.CreditLimit,
        CurrentBalance = req.CreditLimit,
        CreditCardDebt = 0,
        IsActive = true,
        IsPrimary = !hasAnyDebitCard,
      };

      await _CreditCardRepository.AddAsync(creditCard);


      Product product = new()
      {
        IsCreditCard = true,
        ClientId = req.ClientId,
        CreditCardId = creditCard.Id,
        ProductTypeId = (int)EProducts.TARJETA_CREDITO 
      };

      //WE CAN TRY TO FIND THE ID ON THE DATABASE JUST IN CASE THE ID ON DB AND ENUM ARE DIFFERENT
      //HOWEVER, SINCE WE ARE USING SEEDS, WE KNOW THE ID IS THE SAME

      await _productRepository.AddAsync(product);

      creditCard.ProductId = product.Id;

      await _CreditCardRepository.Update(creditCard);

      return _mapper.Map<CreditCardDTO>(creditCard);
    }
  }
}
