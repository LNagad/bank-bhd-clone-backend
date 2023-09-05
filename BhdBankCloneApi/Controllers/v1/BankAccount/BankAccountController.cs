using BhdBankClone.Core.Application.Features.BankAccounts.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.BankAccount
{
  public class BankAccountController : BaseApiController
  {
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromQuery] CreateBankAccountCommand request)
    {
      return Ok(await Mediator.Send(request));
    }
  }
}
