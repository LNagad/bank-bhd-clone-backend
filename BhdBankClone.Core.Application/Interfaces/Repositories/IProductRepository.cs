using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface IProductRepository : IGenericRepository<Product>
  {
    IEnumerable<Product> GetAllProductByClientIdWithInclude(int clientId, List<string> properties);

    IEnumerable<Product> GetAllProductByClientId(int clientId, List<string> properties);

  }
}