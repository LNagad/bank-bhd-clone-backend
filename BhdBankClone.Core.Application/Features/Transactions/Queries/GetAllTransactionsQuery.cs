using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Transactions.Queries
{
  public class GetAllTransactionsQuery : IRequest<Response<List<BankTransaction>>>
  {
  }

  internal class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, Response<List<BankTransaction>>>
  {
    private readonly IGenericRepository<BankTransaction> _repository;

    public GetAllTransactionsQueryHandler(IGenericRepository<BankTransaction> repository)
    {
      _repository = repository;
    }

    public async Task<Response<List<BankTransaction>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
          "Client",
          "DestinationAccount",
          "DestinationCreditCard",
          "SourceAccount",
          "SourceCreditCard",
          "SourceDebitCard",
          "TransactionType",
          "DestinationLoan",
          "SourceLoan"
      };

      var accounts = await _repository.GetAllWithIncludeAsync(parameters);

      return new Response<List<BankTransaction>>(accounts);
    }
  }
}
