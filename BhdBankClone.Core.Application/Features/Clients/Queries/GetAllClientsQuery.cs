using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Clients.Queries
{
  public class GetAllClientsQuery : IRequest<Response<List<ClientDTO>>>
  {

  }

  public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, Response<List<ClientDTO>>>
  {
    private readonly IClientRepository _clientRepository;
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;
    private readonly IMapper _mapper;
    public GetAllClientsQueryHandler(IClientRepository clientRepository, IMapper mapper, IBasicUserExtraAccountService basicUserExtraAccountService)
    {
      _clientRepository = clientRepository;
      _mapper = mapper;
      _basicUserExtraAccountService = basicUserExtraAccountService;
    }

    public async Task<Response<List<ClientDTO>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
      var clients = await _clientRepository.GetAllAsyncList();

      var clientsDTO = _mapper.Map<List<ClientDTO>>(clients);

      foreach (var client in clientsDTO)
      {
        var userFound = await _basicUserExtraAccountService.GetBasicUserByIdAsync(client.UserId);
        client.FirstName = userFound.FirstName;
        client.LastName = userFound.LastName;
      }

      return new Response<List<ClientDTO>>(clientsDTO);
    }
  }
}
