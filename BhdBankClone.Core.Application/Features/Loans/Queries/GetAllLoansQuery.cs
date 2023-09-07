using AutoMapper;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Loans.Queries
{
  public class GetAllLoansQuery : IRequest<Response<List<Loan>>>
  {
  }

  public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, Response<List<Loan>>>
  {
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly IMapper _mapper;
    public GetAllLoansQueryHandler(IGenericRepository<Loan> loanRepository, IMapper mapper)
    {
      _loanRepository = loanRepository;
      _mapper = mapper;
    }

    public async Task<Response<List<Loan>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
          "Client",
          "Product",
          "Account",
          "SourceTransaction",
          "DestinationTransactions"
      };

      return new Response<List<Loan>>(await _loanRepository.GetAllWithIncludeAsync(parameters));
    }
  }
}
