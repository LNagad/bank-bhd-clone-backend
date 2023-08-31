using BhdBankClone.Core.Application.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Moderator
{
  [Authorize(Roles = nameof(Roles.Moderator) + "," + nameof(Roles.Admin))]
  public class ModeratorController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllBasicUsers()
    {
      return Ok("Moderator");
    }
  }
}
