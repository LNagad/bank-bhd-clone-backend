using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Loans.Queries
{
  public class GetAllLoansQuery : IRequest<Response<List<LoanDTO>>>
  {
  }

  public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, Response<List<LoanDTO>>>
  {
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IGenericRepository<TransactionType> _transactionTypeRepository;
    private readonly IMapper _mapper;
    public GetAllLoansQueryHandler(IGenericRepository<Loan> loanRepository, IMapper mapper, ITransactionRepository transactionRepository, IGenericRepository<TransactionType> transactionTypeRepository)
    {
      _loanRepository = loanRepository;
      _mapper = mapper;
      _transactionRepository = transactionRepository;
      _transactionTypeRepository = transactionTypeRepository;
    }

    public async Task<Response<List<LoanDTO>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
          "Client",
          //"Product",
          "Account",
          //"SourceTransaction",
          //"DestinationTransactions"
      };
      var transactions = await _loanRepository.GetAllWithIncludeAsync(parameters);
      var transactionsMapped = _mapper.Map<List<LoanDTO>>(transactions);

      var destinationTransactions = _transactionRepository.GetQueryable()
        .Where(t => t.DestinationLoanId != null);

      var sourceTransactions = _transactionRepository.GetQueryable()
        .Where(t => t.SourceLoanId != null);


      foreach (var loan in transactionsMapped)
      {
        foreach (var transaction in destinationTransactions)
        {
          if (loan.Id == transaction.DestinationLoanId)
          {
            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);

            if (transaction?.TransactionTypeId != null)
            {
              var transactionType = await _transactionTypeRepository.GetByIdAsync(transaction.TransactionTypeId);
              transactionDTO.TransactionType = transactionType?.Description ?? null;
            }

            loan.DestinationTransactions.Add(transactionDTO);
          }
        }

        foreach (var transaction in sourceTransactions)
        {
          if (loan.Id == transaction.SourceLoanId)
          {
            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);

            if (transaction?.TransactionTypeId != null)
            {
              var transactionType = await _transactionTypeRepository.GetByIdAsync(transaction.TransactionTypeId);
              transactionDTO.TransactionType = transactionType?.Description ?? null;
            }

            loan.SourceTransaction = transactionDTO;
          } else
          {
            loan.SourceTransaction = null;
          }
        }
      }

      return new Response<List<LoanDTO>>(transactionsMapped);
    }
  }
}
