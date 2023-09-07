using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.BankAccounts.Queries
{
  public class GetAllBankAccountsByClientIdQuery : IRequest<Response<IEnumerable<Account>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllBankAccountsByClientIdQueryHandler : IRequestHandler<GetAllBankAccountsByClientIdQuery, Response<IEnumerable<Account>>>
  {
    private readonly IAccountRepository _repository;

    public GetAllBankAccountsByClientIdQueryHandler(IAccountRepository repository)
    {
      _repository = repository;
    }

    public async Task<Response<IEnumerable<Account>>> Handle(GetAllBankAccountsByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Products",
        "AccountType",
        "Client",
        "DebitCard",
        "Transactions",
        "Loans",
      };

      var accounts = _repository.GetAccountsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      return new Response<IEnumerable<Account>>(accounts);
    }
  }
}
