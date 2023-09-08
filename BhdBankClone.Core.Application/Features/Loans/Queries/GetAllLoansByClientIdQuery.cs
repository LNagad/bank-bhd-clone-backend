using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Queries
{
  public class GetAllLoansByClientIdQuery : IRequest<Response<IEnumerable<LoanDTO>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllLoansByClientIdQueryHandler : IRequestHandler<GetAllLoansByClientIdQuery, Response<IEnumerable<LoanDTO>>>
  {
    private readonly ILoanRepository _repository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IGenericRepository<TransactionType> _transactionTypeRepository;
    private readonly IMapper _mapper;

    public GetAllLoansByClientIdQueryHandler(ILoanRepository repository, IMapper mapper, ITransactionRepository transactionRepository, IGenericRepository<TransactionType> transactionTypeRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _transactionRepository = transactionRepository;
      _transactionTypeRepository = transactionTypeRepository;
    }

    public async Task<Response<IEnumerable<LoanDTO>>> Handle(GetAllLoansByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
          "Client",
          //"Product",
          "Account",
          //"SourceTransaction",
          //"DestinationTransactions"
      };

      var loans = _repository.GetLoansWithIncludeByClientIdEnumerable(request.ClientId, parameters);
      var loansMapped = _mapper.Map<IEnumerable<LoanDTO>>(loans);

      var transactionsMadeToThisUserLoans = _transactionRepository.GetQueryable()
        .Where(t => t.DestinationLoanId != null && t.ClientId == request.ClientId).ToList();

      var loanTransactionMadeToUser = _transactionRepository.GetQueryable()
        .Where(t => t.SourceLoanId != null && t.ClientId == request.ClientId).ToList();

      foreach (var loan in loansMapped)
      {
        foreach (var transaction in transactionsMadeToThisUserLoans)
        {
          if (loan.Id == transaction.DestinationLoanId)
          {
            var transactionDTO = _mapper.Map<TransactionDTO>(transaction);

            if (transaction?.TransactionTypeId != null)
            {
              var tType = await _transactionTypeRepository.GetByIdAsync(transaction.TransactionTypeId);
              transactionDTO.TransactionType = tType?.Description;
            }

            loan?.DestinationTransactions?.Add(transactionDTO);

          }

          foreach (var loanTransaction in loanTransactionMadeToUser)
          {

            if (loan != null)
            {
              if (loan?.Id == loanTransaction.SourceLoanId)
              {

                var transactionDTO = _mapper.Map<TransactionDTO>(loanTransaction);

                if (transactionDTO?.TransactionTypeId != null)
                {
                  var tType = await _transactionTypeRepository.GetByIdAsync(transactionDTO.TransactionTypeId);
                  transactionDTO.TransactionType = tType?.Description;
                }

                loan.SourceTransaction = transactionDTO;

              }
              else
              {
                loan.SourceTransaction = null;
              }
            }

          }
        }
      }


      return new Response<IEnumerable<LoanDTO>>(loansMapped);
    }
  }
}
