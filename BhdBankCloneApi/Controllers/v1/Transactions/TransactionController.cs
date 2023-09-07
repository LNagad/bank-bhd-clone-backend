using BhdBankClone.Core.Application.Features.Products.Commands;
using BhdBankClone.Core.Application.Features.Transactions.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Transactions
{
  public class TransactionController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllTransactionsQuery()));
    }

    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] GetAllTransactionsByClientIdQuery query)
    {
      return Ok(await Mediator.Send(query));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Post([FromBody] CreateTransactionCommand request)
    {
      return Ok( await Mediator.Send(request) );
    }
  }
}
