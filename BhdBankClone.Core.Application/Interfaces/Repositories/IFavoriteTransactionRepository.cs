using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface IFavoriteTransactionRepository : IGenericRepository<FavoriteTransaction>
  {
    IEnumerable<FavoriteTransaction> GetFavTransactionsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters);
  }
}