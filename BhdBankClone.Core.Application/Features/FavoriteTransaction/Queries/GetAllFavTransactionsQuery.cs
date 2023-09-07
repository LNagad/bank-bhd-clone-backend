using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class GetAllFavTransactionsQuery : IRequest<Response<List<FavoriteTransaction>>>
  {
  }

  internal class GetAllFavTransactionsQueryHandler : IRequestHandler<GetAllFavTransactionsQuery, Response<List<FavoriteTransaction>>>
  {
    private readonly IGenericRepository<FavoriteTransaction> _repository;

    public GetAllFavTransactionsQueryHandler(IGenericRepository<FavoriteTransaction> repository)
    {
      _repository = repository;
    }

    public async Task<Response<List<FavoriteTransaction>>> Handle(GetAllFavTransactionsQuery request, CancellationToken cancellationToken)
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

      var accounts = await _repository.GetAllWithIncludeAsync(parameters);

      return new Response<List<FavoriteTransaction>>(accounts);
    }
  }
}
