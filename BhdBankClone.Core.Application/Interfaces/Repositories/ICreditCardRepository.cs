using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface ICreditCardRepository : IGenericRepository<CreditCard>
  {
    IEnumerable<CreditCard> GetCreditCardsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters);
  }
}