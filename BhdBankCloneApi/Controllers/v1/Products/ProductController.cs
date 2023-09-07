using BhdBankClone.Core.Application.Features.Products.Queries.GetAllProducts;
using BhdBankClone.Core.Application.Features.Products.Queries.GetAllProductsByClientId;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Products
{

  public class ProductController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAll()
    {
      return Ok(await Mediator.Send(new GetAllProductsQuery()));
    }

    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] int ClientId)
    {
      return Ok(await Mediator.Send(new GetAllProductsByClientIdQuery() { ClientId = ClientId } ));
    }
  }
}
