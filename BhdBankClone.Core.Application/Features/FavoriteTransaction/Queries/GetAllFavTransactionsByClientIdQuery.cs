using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class GetAllFavTransactionsByClientIdQuery : IRequest<Response<IEnumerable<FavoriteTransactionDTO>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllFavTransactionsByClientIdQueryHandler : IRequestHandler<GetAllFavTransactionsByClientIdQuery, Response<IEnumerable<FavoriteTransactionDTO>>>
  {
    private readonly IFavoriteTransactionRepository _repository;
    private readonly IMapper _mapper;

    public GetAllFavTransactionsByClientIdQueryHandler(IFavoriteTransactionRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<FavoriteTransactionDTO>>> Handle(GetAllFavTransactionsByClientIdQuery request, CancellationToken cancellationToken)
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

      var favTransactions = _repository.GetFavTransactionsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      var favoriteTransactions = _mapper.Map<IEnumerable<FavoriteTransactionDTO>>(favTransactions);

      foreach (var fav in favoriteTransactions)
      {
        if (fav.DestinationLoan.SourceTransaction.Id == 0 || fav.DestinationLoan.SourceTransaction.Id == null)
        {
          fav.DestinationLoan.SourceTransaction = null;
        }
      }

      return new Response<IEnumerable<FavoriteTransactionDTO>>(favoriteTransactions);
    }
  }
}
