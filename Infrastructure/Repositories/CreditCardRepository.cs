using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class CreditCardRepository : GenericRepository<CreditCard>, ICreditCardRepository
  {
    private readonly ApplicationContext _context;

    public CreditCardRepository(ApplicationContext context) : base(context)
    {
      _context = context;
    }

    public IEnumerable<CreditCard> GetCreditCardsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters)
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
