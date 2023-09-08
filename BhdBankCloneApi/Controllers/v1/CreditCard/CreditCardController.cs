using BhdBankClone.Core.Application.Features.CreditCardResponseQuerys.Queries;
using BhdBankClone.Core.Application.Features.CreditCards.Commands;
using BhdBankClone.Core.Application.Features.CreditCards.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.CreditCard
{
  public class CreditCardController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllCreditCardsQuery()));
    }

    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] int ClientId)
    {
      return Ok(await Mediator.Send(new GetAllCreditCardsByClientIdQuery() { ClientId = ClientId }));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post(CreateCreditCardCommand command)
    {
      return Ok(await Mediator.Send(command));
    }

  }
}
