using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Transactions.Queries
{
  public class GetAllTransactionsByClientIdQuery : IRequest<Response<IEnumerable<BankTransaction>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllTransactionsByClientIdQueryHandler : IRequestHandler<GetAllTransactionsByClientIdQuery, Response<IEnumerable<BankTransaction>>>
  {
    private readonly ITransactionRepository _repository;

    public GetAllTransactionsByClientIdQueryHandler(ITransactionRepository repository)
    {
      _repository = repository;
    }

    public async Task<Response<IEnumerable<BankTransaction>>> Handle(GetAllTransactionsByClientIdQuery request, CancellationToken cancellationToken)
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


      var accounts = _repository.GetTransactionsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      return new Response<IEnumerable<BankTransaction>>(accounts);
    }
  }
}
