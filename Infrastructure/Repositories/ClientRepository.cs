using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class ClientRepository : GenericRepository<Client>, IClientRepository
  {
    private readonly ApplicationContext _context;

    public ClientRepository(ApplicationContext context) : base(context) 
    {
      _context = context;
    }

    public async Task<Client?> GetClientByIdentityUserIdAsync(string identityUserId)
    {
      return await _context.Clients.FirstOrDefaultAsync(c => c.UserId == identityUserId);
    }
  }
}
