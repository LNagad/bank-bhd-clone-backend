using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Clients.Queries
{
  public class GetClientByIdentityUserIdQuery : IRequest<Response<ClientDTO>>
  {
    public required string IdentityUserId { get; set; }
  }

  internal class GetClientByIdentityUserIdQueryHandler : IRequestHandler<GetClientByIdentityUserIdQuery, Response<ClientDTO>>
  {
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;
    public GetClientByIdentityUserIdQueryHandler(IClientRepository clientRepository, IMapper mapper, IBasicUserExtraAccountService basicUserExtraAccountService)
    {
      _clientRepository = clientRepository;
      _mapper = mapper;
      _basicUserExtraAccountService = basicUserExtraAccountService;
    }

    public async Task<Response<ClientDTO>> Handle(GetClientByIdentityUserIdQuery request, CancellationToken cancellationToken)
    {
      var client = await _clientRepository.GetClientByIdentityUserIdAsync(request.IdentityUserId);

      if (client == null)
      {
        return new Response<ClientDTO>() { Data = null, Succeeded = false, Message = "No client found" };
      }

      return new Response<ClientDTO>() { Data = _mapper.Map<ClientDTO>(client) };
    }
  }
}
