using BhdBankClone.Core.Application.Features.DebitCards.Queries;
using BhdBankClone.Core.Application.Features.Loans.Commands;
using BhdBankClone.Core.Application.Features.Loans.Queries;
using Microsoft.AspNetCore.Mvc;

namespace BhdBankCloneApi.Controllers.v1.Loans
{
  public class LoansController : BaseApiController
  {
    // GET: api/Loans
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
      return Ok(await Mediator.Send(new GetAllLoansQuery()));
    }

    // GET: api/Loans/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
      return "not implemented yet";
    }

    // GET: api/Loans/ClientId
    [HttpGet("ClientId")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetByClientId([FromQuery] GetAllLoansByClientIdQuery query)
    {
      return Ok(await Mediator.Send(query));
    }

    // POST: api/Loans
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
    {
      return Ok(await Mediator.Send(command));
    }

    // PUT: api/Loans/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
