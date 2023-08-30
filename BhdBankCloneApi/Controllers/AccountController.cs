using BhdBankClone.Core.Application.DTOs.Account;
using BhdBankClone.Core.Application.Features.Account.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BhdBankCloneApi.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : BaseApiController
  {
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(new
      {
        message = "SecurityController"
      });
    }

    [HttpPost("authenticate")]
    [ProducesResponseType(typeof(AuthenticationResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest req)
    {
      return Ok(await Mediator.Send(new AuthenticateCommand() { authenticationRequest = req }));
    }

  }
}
