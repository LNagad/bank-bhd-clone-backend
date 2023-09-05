using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{
  public class ClientRepository : GenericRepository<Client>, IClientRepository
  {
    private readonly ApplicationContext _context;

    public ClientRepository(ApplicationContext context) : base(context) 
    {
      _context = context;
    }
  }
}
