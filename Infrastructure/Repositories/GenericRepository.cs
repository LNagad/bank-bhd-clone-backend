using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : AuditableBaseEntity
  {
    private readonly BhdContext _context;
    protected readonly DbSet<Entity> _entities;

    public GenericRepository(BhdContext context)
    {
      _context = context;
      _entities = context.Set<Entity>();
    }

    public virtual async Task<Entity> AddAsync(Entity entity)
    {
      await _context.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public virtual async Task<List<Entity>> GetAllAsyncList()
    {
      return await _context.Set<Entity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<List<Entity>> GetAllWithIncludeAsync(List<string> parameters)
    {
      var query = _context.Set<Entity>().AsQueryable();

      foreach (var param in parameters)
      {
        query = query.Include(param);
      };

      return await query.ToListAsync();
    }

    public virtual async Task<List<Entity>> GetAllAsyncPaginatedList(int pageSize, int pageNumber)
    {
      var skip = (pageNumber - 1) * pageSize;
      return await _context.Set<Entity>().AsNoTracking().Skip(skip).Take(pageSize).ToListAsync();
    }

    public virtual IQueryable<Entity> GetQueryable()
    {
      return _context.Set<Entity>().AsNoTracking().AsQueryable();
    }

    public virtual async IAsyncEnumerable<Entity> GetAllAsyncEnumerable()
    {
      await using var enumerator = _context.Set<Entity>().AsAsyncEnumerable().GetAsyncEnumerator();
      while (await enumerator.MoveNextAsync())
        yield return enumerator.Current;
    }

    public virtual IEnumerable<Entity> GetAllEnumerable()
    {
      return _context.Set<Entity>().AsNoTracking().AsEnumerable();
    }

    public virtual async Task<Entity?> GetByIdAsync(int id)
    {
      return await _entities.FindAsync(id);
    }

    public virtual async Task<Entity?> GetByIdWithIncludeAsync(int id, List<string> properties)
    {
      var query = _entities.AsQueryable();

      foreach (var property in properties)
      {
        query = query.Include(property);
      }

      var result = await query.FirstOrDefaultAsync(p => p.Id == id);

      return result;
    }

    public async Task<int> CountAsync()
    {
      return await _context.Set<Entity>().CountAsync();
    }

    public virtual async Task<Entity> Update(Entity entity)
    {
      _context.Set<Entity>().Update(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public virtual async Task Remove(Entity entity)
    {
      await _context.SaveChangesAsync();
      _context.Set<Entity>().Remove(entity);
    }

    public virtual async Task<int> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync();
    }

  }
}
