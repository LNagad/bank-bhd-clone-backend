using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class GetAllCreditCardsByClientIdQuery : IRequest<Response<IEnumerable<CreditCard>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllCreditCardsByClientIdQueryHandler : IRequestHandler<GetAllCreditCardsByClientIdQuery, Response<IEnumerable<CreditCard>>>
  {
    private readonly ICreditCardRepository _repository;

    public GetAllCreditCardsByClientIdQueryHandler(ICreditCardRepository repository)
    {
      _repository = repository;
    }

    public async Task<Response<IEnumerable<CreditCard>>> Handle(GetAllCreditCardsByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        "Product",
        "Transactions"
      };

      var accounts = _repository.GetCreditCardsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      return new Response<IEnumerable<CreditCard>>(accounts);
    }
  }
}
