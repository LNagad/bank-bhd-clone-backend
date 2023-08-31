using BhdBankClone.Core.Application.DTOs.Account;
using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Features.Account.Commands;
using BhdBankClone.Core.Application.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BhdBankCloneApi.Controllers
{
  //[Route("api/[controller]")]
  //[Authorize(Roles = nameof(Roles.Moderator)+","+nameof(Roles.Admin))]
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

    //[AllowAnonymous]
    [HttpPost("authenticate")]
    [ProducesResponseType(typeof(Response<AuthenticationResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest req)
    {
      return Ok(await Mediator.Send(new AuthenticateCommand() { AuthenticationRequest = req }));
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(Response<RegisterResponse>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest req, [FromHeader] string origin)
    {
      return Ok(await Mediator.Send(new RegisterCommand() { RegisterRequest = req, Origin = origin }));
    }

    [HttpPost("confirm-account")]
    [ProducesResponseType(typeof(AuthenticationResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ConfirmAccountAsync([FromQuery] ConfirmAccountRequest req)
    {
      return Ok(await Mediator.Send(new ConfirmAccountCommand() { ConfirmAccountRequest = req }));
    }

    [HttpPost("forgot-password")]
    [ProducesResponseType(typeof(AuthenticationResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequest req, [FromHeader] string origin)
    {
      return Ok(await Mediator.Send(new ForgotPasswordCommand() { ForgotPasswordRequest = req, Origin = origin }));
    }

    [HttpPost("reset-password")]
    [ProducesResponseType(typeof(AuthenticationResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequest req )
    {
      return Ok(await Mediator.Send(new ResetPasswordCommand() { ResetPasswordRequest = req }));
    }

  }
}
