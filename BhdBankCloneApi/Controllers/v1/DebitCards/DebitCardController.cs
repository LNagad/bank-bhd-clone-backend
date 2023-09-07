using BhdBankClone.Core.Application.Features.DebitCards.Commands;
using BhdBankClone.Core.Application.Features.DebitCards.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.DebitCards
{
  public class DebitCardController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllDebitCardsQuery()));
    }

    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] GetAllDebitCardsByClientIdQuery query)
    {
      return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateDebitCard(CreateDebitCardCommand command)
    {
      return Ok(await Mediator.Send(command));
    }

  }
}

