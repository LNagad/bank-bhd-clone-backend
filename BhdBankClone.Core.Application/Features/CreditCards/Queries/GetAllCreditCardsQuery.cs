using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class GetAllCreditCardsQuery : IRequest<Response<List<CreditCard>>>
  {
  }

  internal class GetAllCreditCardsQueryHandler : IRequestHandler<GetAllCreditCardsQuery, Response<List<CreditCard>>>
  {
    private readonly IGenericRepository<CreditCard> _repository;

    public GetAllCreditCardsQueryHandler(IGenericRepository<CreditCard> repository)
    {
      _repository = repository;
    }

    public async Task<Response<List<CreditCard>>> Handle(GetAllCreditCardsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        "Product",
        "Transactions"
      };

      var accounts = await _repository.GetAllWithIncludeAsync(parameters);

      return new Response<List<CreditCard>>(accounts);
    }
  }
}
