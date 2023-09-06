using BhdBankClone.Core.Application.Features.CreditCards.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.CreditCard
{
  public class CreditCardController : BaseApiController
  {
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> CreateCreditCard(CreateCreditCardCommand command)
    {
      return Ok(await Mediator.Send(command));
    }
  }
}
