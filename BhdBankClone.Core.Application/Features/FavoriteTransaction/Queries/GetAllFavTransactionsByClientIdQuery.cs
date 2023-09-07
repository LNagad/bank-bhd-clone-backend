using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class GetAllFavTransactionsByClientIdQuery : IRequest<Response<IEnumerable<FavoriteTransaction>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllFavTransactionsByClientIdQueryHandler : IRequestHandler<GetAllFavTransactionsByClientIdQuery, Response<IEnumerable<FavoriteTransaction>>>
  {
    private readonly IFavoriteTransactionRepository _repository;

    public GetAllFavTransactionsByClientIdQueryHandler(IFavoriteTransactionRepository repository)
    {
      _repository = repository;
    }

    public async Task<Response<IEnumerable<FavoriteTransaction>>> Handle(GetAllFavTransactionsByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
          "Client",
          "DestinationAccount",
          "DestinationCreditCard",
          "SourceAccount",
          "SourceCreditCard",
          "SourceDebitCard",
          "TransactionType",
          "DestinationLoan",
          //"SourceLoan"
      };

      var accounts = _repository.GetFavTransactionsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      return new Response<IEnumerable<FavoriteTransaction>>(accounts);
    }
  }
}
