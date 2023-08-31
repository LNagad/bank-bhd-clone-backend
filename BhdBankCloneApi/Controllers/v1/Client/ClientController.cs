using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Features.Clients.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Client
{
  [Authorize(Roles = nameof(Roles.Moderator) + "," + nameof(Roles.Admin))]
  public class ClientController : BaseApiController
  {
    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientCommand req)
    {
      return Ok(await Mediator.Send(req));
    }
  }
}
