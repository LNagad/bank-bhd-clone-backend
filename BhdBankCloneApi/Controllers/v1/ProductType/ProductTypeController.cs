using BhdBankClone.Core.Application.Features.ProductTypes.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.ProductType
{
  public class ProductTypeController : BaseApiController
  {
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromQuery] CreateProductTypeCommand request)
    {
      return Ok(await Mediator.Send(request));
    }
  }
}
