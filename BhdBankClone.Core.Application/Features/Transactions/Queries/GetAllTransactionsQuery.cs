using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Transactions.Queries
{
  public class GetAllTransactionsQuery : IRequest<Response<IEnumerable<TransactionDTO>>>
  {
  }

  internal class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, Response<IEnumerable<TransactionDTO>>>
  {
    private readonly IGenericRepository<BankTransaction> _repository;
    private readonly IMapper _mapper;


    public GetAllTransactionsQueryHandler(IGenericRepository<BankTransaction> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<TransactionDTO>>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
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

      var transactions = await _repository.GetAllWithIncludeAsync(parameters);
      var transactionsMapped = _mapper.Map<IEnumerable<TransactionDTO>>(transactions);

      return new Response<IEnumerable<TransactionDTO>>(transactionsMapped);
    }
  }
}
