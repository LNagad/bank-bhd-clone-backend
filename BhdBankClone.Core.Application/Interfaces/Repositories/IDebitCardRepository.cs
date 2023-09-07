using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface IDebitCardRepository : IGenericRepository<DebitCard>
  {
    IEnumerable<DebitCard> GetDebitCardsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters);
  }
}