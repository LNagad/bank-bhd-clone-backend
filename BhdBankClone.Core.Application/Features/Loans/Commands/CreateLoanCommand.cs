using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Loans;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Loans.Commands
{
  public class CreateLoanCommand : IRequest<Response<LoanDTO>>
  {
    public double? LoanAmount { get; set; }

    public int ClientId { get; set; }
  }
  public class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Response<LoanDTO>>
  {
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateLoanCommand> _validator;

    public CreateLoanCommandHandler(IGenericRepository<Loan> LoanRepository, IMapper mapper, IValidator<CreateLoanCommand> validator, IClientRepository clientRepository)
    {
      _loanRepository = LoanRepository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
    }

    public async Task<Response<LoanDTO>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<LoanDTO>() { Data = await CreateLoanAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<LoanDTO> CreateLoanAsync(CreateLoanCommand req)
    {
      var clientExist = await _clientRepository.GetByIdAsync(req.ClientId);

      if (clientExist == null) throw new ApiException($"Client with id: {req.ClientId} does not exist.");

      var Loan = await _loanRepository.AddAsync(_mapper.Map<Loan>(req));

      return _mapper.Map<LoanDTO>(Loan);
    }
  }
}
