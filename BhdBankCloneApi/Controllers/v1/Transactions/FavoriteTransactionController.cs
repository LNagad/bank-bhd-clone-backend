using BhdBankClone.Core.Application.Features.CreditCards.Queries;
using BhdBankClone.Core.Application.Features.Products.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Transactions
{
  public class FavoriteTransactionController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllFavTransactionsQuery()));
    }

    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] GetAllFavTransactionsByClientIdQuery query)
    {
      return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] CreateFavoriteTransactionCommand request)
    {
      return Ok( await Mediator.Send(request) );
    }
  }
}
