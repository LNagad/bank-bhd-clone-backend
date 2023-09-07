using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.BankAccounts.Queries
{
    public class GetAllBankAccountsQuery : IRequest<Response<List<Account>>>
    {
    }

    internal class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, Response<List<Account>>>
    {
        private readonly IGenericRepository<Account> _repository;

        public GetAllBankAccountsQueryHandler(IGenericRepository<Account> repository)
        {
            _repository = repository;
        }

        public async Task<Response<List<Account>>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
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

            var accounts = await _repository.GetAllWithIncludeAsync(parameters);

            return new Response<List<Account>>(accounts);
        }
    }
}
