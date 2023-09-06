using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Features.Clients.Commands;
using BhdBankClone.Core.Application.Features.Clients.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Client
{
  //[Authorize(Roles = nameof(Roles.Moderator) + "," + nameof(Roles.Admin))]
  public class ClientController : BaseApiController
  {
    [HttpGet]
    public async Task<IActionResult> GetAllClients()
    {
      return Ok(await Mediator.Send(new GetAllClientsQuery()));
    }

    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientCommand req)
    {
      return Ok(await Mediator.Send(req));
    }
  }
}
