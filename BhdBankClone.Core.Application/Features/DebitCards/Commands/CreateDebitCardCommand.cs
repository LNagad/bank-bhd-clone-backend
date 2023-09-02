using AutoMapper;
using BhdBankClone.Core.Application.DTOs.DebitCards;
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
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateDebitCardCommand> _validator;

    public CreateDebitCardCommandHandler(IGenericRepository<DebitCard> DebitCardRepository, IMapper mapper, IValidator<CreateDebitCardCommand> validator, IClientRepository clientRepository)
    {
      _DebitCardRepository = DebitCardRepository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
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

      //TODO: Check if client has an account with the account id provided

      DebitCard debitCard = new()
      {
        CardNumber = GenerateRandom.GenerateRandomNumber(16),
        CardCvv = GenerateRandom.GenerateRandomNumber(3),
        CardExpiryDate = DateTime.Now.AddYears(5),
        ClientId = req.ClientId,
        AccountId = req.AccountId,
        IsActive = true,
        IsPrimary = true, //TODO: Check if client already has a debit card to set it as primary to true or false
      };

      var DebitCard = await _DebitCardRepository.AddAsync(debitCard);

      return _mapper.Map<DebitCardDTO>(DebitCard);
    }
  }
}
