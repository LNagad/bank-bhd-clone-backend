using AutoMapper;
using BhdBankClone.Core.Application.DTOs.DebitCards;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.BankAccounts.Queries
{
  public class GetAllBankAccountsByClientIdQuery : IRequest<Response<List<BankAccountQueryResponse>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllBankAccountsByClientIdQueryHandler : IRequestHandler<GetAllBankAccountsByClientIdQuery, Response<List<BankAccountQueryResponse>>>
  {
    private readonly IAccountRepository _repository;
    private readonly IProductRepository _productRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IDebitCardRepository _debitCardRepository;
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;
    private readonly IMapper _mapper;

    public GetAllBankAccountsByClientIdQueryHandler(IAccountRepository repository,
      IMapper mapper, ITransactionRepository transactionRepository,
      IBasicUserExtraAccountService basicUserExtraAccountService,
      IProductRepository productRepository, IDebitCardRepository debitCardRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _transactionRepository = transactionRepository;
      _basicUserExtraAccountService = basicUserExtraAccountService;
      _productRepository = productRepository;
      _debitCardRepository = debitCardRepository;
    }

    public async Task<Response<List<BankAccountQueryResponse>>> Handle(GetAllBankAccountsByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        //"Products",
        "AccountType",
        "Client",
        //"DebitCard",
        //"Transactions",
        "Loans",
      };

      var accounts = _repository.GetAccountsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      var mappedAccounts = _mapper.Map<List<BankAccountQueryResponse>>(accounts);

      foreach (var account in mappedAccounts)
      {

        var getUserTask = _basicUserExtraAccountService.GetBasicUserByIdAsync(account.Client.UserId);
        var getTransactionsTask = Task.Run(() => _transactionRepository.GetQueryable());

        await Task.WhenAll(getUserTask, getTransactionsTask);

        var userFound = await getUserTask;
        var transactions = getTransactionsTask.Result;

        account.Client.LastName = userFound.LastName;
        account.Client.FirstName = userFound.FirstName;

        account.TransactionsAsSource = _mapper.
          Map<List<TransactionDTO>>(transactions.Where(t => t.SourceAccountId == account.Id).ToList());

        account.TransactionsAsDestination = _mapper.
          Map<List<TransactionDTO>>(transactions.Where(t => t.DestinationAccountId == account.Id).ToList());

        account.Products = _mapper
          .Map<List<ProductDTO>>(_productRepository
          .GetAllProductByClientId(account.ClientId.Value, new List<string> { "" }));

        account.DebitCards = _mapper
          .Map<List<DebitCardDTO>>(_debitCardRepository
          .GetDebitCardsByClientIdEnumerable(account.ClientId.Value));
      }

      return new Response<List<BankAccountQueryResponse>>(mappedAccounts);
    }
  }
}
