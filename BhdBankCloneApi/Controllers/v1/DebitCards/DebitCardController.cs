using BhdBankClone.Core.Application.Features.DebitCards.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.DebitCards
{
  public class DebitCardController : BaseApiController
  {
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDebitCard(CreateDebitCardCommand command)
    {
      return Ok(await Mediator.Send(command));
    }
  }
}
