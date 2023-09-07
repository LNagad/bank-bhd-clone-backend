using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Queries
{
  public class GetAllDebitCardsByClientIdQuery : IRequest<Response<IEnumerable<DebitCard>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllDebitCardsByClientIdQueryHandler : IRequestHandler<GetAllDebitCardsByClientIdQuery, Response<IEnumerable<DebitCard>>>
  {
    private readonly IDebitCardRepository _repository;

    public GetAllDebitCardsByClientIdQueryHandler(IDebitCardRepository repository)
    {
      _repository = repository;
    }

    public async Task<Response<IEnumerable<DebitCard>>> Handle(GetAllDebitCardsByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        "Product",
        "Account",
        "Transactions"
      };

      var accounts = _repository.GetDebitCardsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      return new Response<IEnumerable<DebitCard>>(accounts);
    }
  }
}
