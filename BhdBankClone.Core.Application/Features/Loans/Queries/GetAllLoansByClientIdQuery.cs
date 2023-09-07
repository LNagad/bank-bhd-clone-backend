using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Queries
{
  public class GetAllLoansByClientIdQuery : IRequest<Response<IEnumerable<Loan>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllLoansByClientIdQueryHandler : IRequestHandler<GetAllLoansByClientIdQuery, Response<IEnumerable<Loan>>>
  {
    private readonly ILoanRepository _repository;

    public GetAllLoansByClientIdQueryHandler(ILoanRepository repository)
    {
      _repository = repository;
    }

    public async Task<Response<IEnumerable<Loan>>> Handle(GetAllLoansByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
          "Client",
          "Product",
          "Account",
          "SourceTransaction",
          "DestinationTransactions"
      };

      var loans = _repository.GetLoansWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      return new Response<IEnumerable<Loan>>(loans);
    }
  }
}
