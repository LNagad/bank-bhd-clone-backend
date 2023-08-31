using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.Clients.Commands
{
  public class CreateClientCommand : IRequest<Response<ClientDTO>>
  {
    public required string UserId { get; set; }
    public int? ClientsTypeId { get; set; }
    public required string IdentityCard { get; set; }
    public int? StatusId { get; set; }
  }
  public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<ClientDTO>>
  {
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateClientCommand> _validator;
    private readonly IBasicUserExtraAccountService _accountService;

    public CreateClientCommandHandler(IClientRepository clientRepository, IMapper mapper, 
      IValidator<CreateClientCommand> validator, IBasicUserExtraAccountService accountService)
    {
      _clientRepository = clientRepository;
      _mapper = mapper;
      _validator = validator;
      _accountService = accountService;
    }

    public async Task<Response<ClientDTO>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<ClientDTO>() { Data = await CreateClientAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<ClientDTO> CreateClientAsync(CreateClientCommand req)
    {
      bool userIdExist = await _accountService.UserExist(req.UserId);

      if (!userIdExist) throw new ApiException("User does not exist", (int)HttpStatusCode.BadRequest);

      var clientQuery = _clientRepository.GetQueryable();

      var clientWithCardIdExist = clientQuery.Where(x => x.IdentityCard == req.IdentityCard).FirstOrDefault();
      var clientWithUserIdExist = clientQuery.Where(x => x.UserId == req.UserId).FirstOrDefault();

      if (clientWithCardIdExist != null || clientWithUserIdExist != null)
      {
        throw new ApiException("A Client already exist", (int)HttpStatusCode.BadRequest);
      }

      // TODO: validate client type and status
      var resp = await _clientRepository.AddAsync(_mapper.Map<Client>(req));

      if (resp == null) throw new ApiException("Could not create client", (int)HttpStatusCode.BadRequest);

      return _mapper.Map<ClientDTO>(resp);
    }
  }
}
