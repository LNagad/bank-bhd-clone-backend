using BhdBankClone.Core.Application.Enums;
using BhdBankClone.Core.Application.Features.Products.Queries.GetAllProducts;
using BhdBankClone.Core.Application.Features.Products.Queries.GetAllProductsByClientId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Products
{
  //[Authorize(Roles = nameof(Roles.Moderator) + "," + nameof(Roles.Admin))]
  public class ProductController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllProductsQuery()));
    }
    //[Authorize(Roles = nameof(Roles.Moderator) + "," + nameof(Roles.Admin) + "," + nameof(Roles.Basic))]
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
