using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface ITransactionRepository : IGenericRepository<BankTransaction>
  {
    IEnumerable<BankTransaction> GetTransactionsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters);
  }
}