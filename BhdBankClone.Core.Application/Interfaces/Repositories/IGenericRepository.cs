﻿using BhdBankClone.Core.Domain.Common;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface IGenericRepository<Entity> where Entity : AuditableBaseEntity
  {
    Task<Entity> AddAsync(Entity entity);
    Task<int> CountAsync();
    IAsyncEnumerable<Entity> GetAllAsyncEnumerable();
    IEnumerable<Entity> GetAllEnumerable();
    Task<List<Entity>> GetAllAsyncList();
    Task<List<Entity>> GetAllAsyncPaginatedList(int pageSize, int pageNumber);
    Task<List<Entity>> GetAllWithIncludeAsync(List<string> parameters);
    Task<Entity?> GetByIdAsync(int id);
    Task<Entity?> GetByIdWithIncludeAsync(int id, List<string> properties);
    IQueryable<Entity> GetQueryable();
    Task Remove(Entity entity);
    Task<int> SaveChangesAsync();
    Task<Entity> Update(Entity entity);
  }
}