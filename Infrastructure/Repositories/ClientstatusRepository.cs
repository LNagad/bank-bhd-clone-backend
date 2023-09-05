using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{

  internal class ClientstatusRepository: GenericRepository<ClientStatus>, IClientStatusRepository
  {
    private readonly ApplicationContext _context;

    public ClientstatusRepository(ApplicationContext context) : base(context)
    {
      _context = context;
    }
  }
}
