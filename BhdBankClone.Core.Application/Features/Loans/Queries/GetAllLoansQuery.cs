using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Loans;
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
    private readonly IMapper _mapper;
    public GetAllLoansQueryHandler(IGenericRepository<Loan> loanRepository, IMapper mapper)
    {
      _loanRepository = loanRepository;
      _mapper = mapper;
    }

    public async Task<Response<List<LoanDTO>>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
    {
      return new Response<List<LoanDTO>>(_mapper.Map<List<LoanDTO>>(_loanRepository.GetAllEnumerable()));
    }
  }
}
