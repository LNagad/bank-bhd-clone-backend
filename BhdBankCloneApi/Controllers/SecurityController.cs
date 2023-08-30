using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SecurityController : ControllerBase
  {
    [HttpGet]
    public IActionResult Get()
    {
      return Ok(new
      {
        message = "SecurityController"
      });
    }
  }
}
