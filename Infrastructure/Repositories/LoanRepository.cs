using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class LoanRepository : GenericRepository<Loan>, ILoanRepository
  {
    private readonly ApplicationContext _context;

    public LoanRepository(ApplicationContext context) : base(context)
    {
      _context = context;
    }

    public IEnumerable<Loan> GetLoansWithIncludeByClientIdEnumerable(int clientId, List<string> parameters)
    {
      var query = _entities.AsQueryable();

      query = query.Where(c => c.ClientId == clientId);

      foreach (var param in parameters)
      {
        query = query.Include(param);
      };

      return query.AsEnumerable();
    }
  }
}
