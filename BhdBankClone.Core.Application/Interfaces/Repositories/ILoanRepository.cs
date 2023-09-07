using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface ILoanRepository : IGenericRepository<Loan>
  {
    IEnumerable<Loan> GetLoansWithIncludeByClientIdEnumerable(int clientId, List<string> parameters);
  }
}