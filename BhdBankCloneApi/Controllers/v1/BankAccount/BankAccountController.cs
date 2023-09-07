using BhdBankClone.Core.Application.Features.BankAccounts.Commands;
using BhdBankClone.Core.Application.Features.BankAccounts.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.BankAccount
{
  public class BankAccountController : BaseApiController
  {
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllBankAccountsQuery()));
    }

    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] int ClientId)
    {
      return Ok(await Mediator.Send(new GetAllBankAccountsByClientIdQuery() { ClientId = ClientId }));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post([FromQuery] CreateBankAccountCommand request)
    {
      return Ok(await Mediator.Send(request));
    }

  }
}
