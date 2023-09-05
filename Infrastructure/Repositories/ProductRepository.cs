using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class ProductRepository : GenericRepository<Product>, IProductRepository
  {
    private readonly ApplicationContext _dbContext;
    public ProductRepository(ApplicationContext dbContext) : base(dbContext)
    {
      _dbContext = dbContext;
    }

    public virtual IEnumerable<Product> GetAllProductByClientIdWithInclude(int clientId, List<string> properties)
    {
      var productsQuery = base.GetQueryable();

      foreach (var property in properties)
      {
        productsQuery = productsQuery.Include(property).Where(p => p.ClientId == clientId);
      }

      return productsQuery;
    }

    public virtual IEnumerable<Product> GetAllProductByClientId(int clientId, List<string> properties)
    {
      //var products = _dbContext.Database.SqlQueryRaw<Product>("select * from Products where ClientId = {0}", clientId);
      //var products = _dbContext.Products.FromSqlInterpolated($"select * from Products where ClientId = {clientId}");
      var products = _dbContext.Products.FromSqlRaw("select * from Products where ClientId = {0}", clientId);

      return products;
    }

  }
}
