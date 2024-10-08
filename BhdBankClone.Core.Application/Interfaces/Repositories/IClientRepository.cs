﻿using BhdBankClone.Core.Domain;

namespace BhdBankClone.Core.Application.Interfaces.Repositories
{
  public interface IClientRepository : IGenericRepository<Client>
  {
    Task<Client?> GetClientByIdentityUserIdAsync(string identityUserId);
  }
}
