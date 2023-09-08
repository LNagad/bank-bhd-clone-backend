using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Transactions.Queries
{
  public class GetAllTransactionsByClientIdQuery : IRequest<Response<IEnumerable<TransactionDTO>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllTransactionsByClientIdQueryHandler : IRequestHandler<GetAllTransactionsByClientIdQuery, Response<IEnumerable<TransactionDTO>>>
  {
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    public GetAllTransactionsByClientIdQueryHandler(ITransactionRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<TransactionDTO>>> Handle(GetAllTransactionsByClientIdQuery request, CancellationToken cancellationToken)
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
          "DestinationLoan"
          //"SourceLoan"
      };

      var transactions = _repository.GetTransactionsWithIncludeByClientIdEnumerable(request.ClientId, parameters);
      var transactionsMapped = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);

      return new Response<IEnumerable<TransactionDTO>>(transactionsMapped);
    }
  }
}
