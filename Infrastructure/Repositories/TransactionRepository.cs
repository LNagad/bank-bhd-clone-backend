﻿using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class TransactionRepository : GenericRepository<BankTransaction>, ITransactionRepository
  {
    private readonly ApplicationContext _context;

    public TransactionRepository(ApplicationContext context) : base(context)
    {
      _context = context;
    }

    public IEnumerable<BankTransaction> GetTransactionsWithIncludeByClientIdEnumerable(int clientId, List<string> parameters)
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
