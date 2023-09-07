using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Queries
{
  public class GetAllDebitCardsQuery : IRequest<Response<List<DebitCard>>>
  {
  }

  internal class GetAllDebitCardsQueryHandler : IRequestHandler<GetAllDebitCardsQuery, Response<List<DebitCard>>>
  {
    private readonly IGenericRepository<DebitCard> _repository;

    public GetAllDebitCardsQueryHandler(IGenericRepository<DebitCard> repository)
    {
      _repository = repository;
    }

    public async Task<Response<List<DebitCard>>> Handle(GetAllDebitCardsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        "Product",
        "Account",
        "Transactions"
      };

      var debitCards = await _repository.GetAllWithIncludeAsync(parameters);

      return new Response<List<DebitCard>>(debitCards);
    }
  }
}
