using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Features.Clients.Commands;
using BhdBankClone.Core.Application.Features.Clients.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Client
{
  [Authorize(Roles = nameof(Roles.Moderator) + "," + nameof(Roles.Admin))]
  public class ClientController : BaseApiController
  {
    // GET: api/Client
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllClientsQuery()));
    }

    // GET: api/Client/IdentityUserId
    
    [Authorize(Roles = nameof(Roles.Moderator) +","+ nameof(Roles.Admin) +","+ nameof(Roles.Basic))]
    [HttpGet("IdentityUserId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetClientByUserId([FromQuery] GetClientByIdentityUserIdQuery query)
    {
      return Ok(await Mediator.Send(query));
    }

    // POST: api/Client

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateClient(CreateClientCommand req)
    {
      return Ok(await Mediator.Send(req));
    }

  }
}
