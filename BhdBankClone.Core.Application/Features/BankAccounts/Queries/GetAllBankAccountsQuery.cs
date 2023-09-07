using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.BankAccounts.Queries
{
  public class GetAllBankAccountsQuery : IRequest<Response<List<BankAccountQueryResponse>>>
  {
  }

  internal class GetAllBankAccountsQueryHandler : IRequestHandler<GetAllBankAccountsQuery, Response<List<BankAccountQueryResponse>>>
  {
    private readonly IAccountRepository _repository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;
    private readonly IMapper _mapper;

    public GetAllBankAccountsQueryHandler(IAccountRepository repository, IMapper mapper, IBasicUserExtraAccountService basicUserExtraAccountService, ITransactionRepository transactionRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _basicUserExtraAccountService = basicUserExtraAccountService;
      _transactionRepository = transactionRepository;
    }

    public async Task<Response<List<BankAccountQueryResponse>>> Handle(GetAllBankAccountsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Products",
        "AccountType",
        "Client",
        "DebitCard",
        //"Transactions",
        "Loans",
        "Client.ClientType"
      };

      var accounts = await _repository.GetAllWithIncludeAsync(parameters);

      var mappedClients = _mapper.Map<List<BankAccountQueryResponse>>(accounts);

      foreach (var account in mappedClients)
      {
        //var userFound = await _basicUserExtraAccountService.GetBasicUserByIdAsync(account.Client.UserId);
        //var transactions = _transactionRepository.GetQueryable();

        var getUserTask = _basicUserExtraAccountService.GetBasicUserByIdAsync(account.Client.UserId);
        var getTransactionsTask = Task.Run(() => _transactionRepository.GetQueryable());

        await Task.WhenAll(getUserTask, getTransactionsTask);

        var userFound = await getUserTask;
        var transactions = getTransactionsTask.Result;


        account.TransactionsAsSource = _mapper.
          Map<List<TransactionDTO>>(transactions.Where(t => t.SourceAccountId == account.Id).ToList());
        
        account.TransactionsAsDestination = _mapper.
          Map<List<TransactionDTO>>(transactions.Where(t => t.DestinationAccountId == account.Id).ToList());

        account.Client.FirstName = userFound.FirstName;
        account.Client.LastName = userFound.LastName;
      }

      return new Response<List<BankAccountQueryResponse>>(mappedClients);
    }
  }
}
