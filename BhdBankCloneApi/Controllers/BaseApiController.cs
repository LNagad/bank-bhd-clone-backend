using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers
{
  [Produces("application/json")]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ProducesResponseType(StatusCodes.Status500InternalServerError)]
  [ProducesResponseType(StatusCodes.Status401Unauthorized)]
  [ProducesResponseType(StatusCodes.Status403Forbidden)]
  public class BaseApiController : ControllerBase
  {
    private IMediator _mediator;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
  }
}
