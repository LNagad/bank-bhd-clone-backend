using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        IEnumerable<Account> GetAccountsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters);
    }
}