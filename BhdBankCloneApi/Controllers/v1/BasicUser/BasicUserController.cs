using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Features.Account.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.BasicUser
{

  [Authorize(Roles = nameof(Roles.Moderator)+","+nameof(Roles.Admin))]
  public class BasicUserController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllBasicUsers()
    {
      return Ok( await Mediator.Send(new GetAllBasicUserQuery() ));
    }
  }
}
