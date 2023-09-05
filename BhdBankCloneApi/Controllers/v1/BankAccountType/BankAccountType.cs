using BhdBankClone.Core.Application.Features.BankAccountTypes.Command;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.BankAccountType
{
  public class BankAccountType : BaseApiController
  {
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromQuery] CreateBankAccountTypeCommand request)
    {
      return Ok(await Mediator.Send(request));
    }
  }
}
