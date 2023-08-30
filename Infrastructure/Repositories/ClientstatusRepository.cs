using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Domain;
using Infrastructure.Persistence;

namespace BhdBankClone.Infrastructure.Persistence.Repositories
{

  internal class ClientstatusRepository: GenericRepository<ClientStatus>, IClientStatusRepository
  {
    private readonly BhdContext _context;

    public ClientstatusRepository(BhdContext context) : base(context)
    {
      _context = context;
    }
  }
}
