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
  internal class CreateLoanCommandHandler : IRequestHandler<CreateLoanCommand, Response<LoanDTO>>
  {
    private readonly IGenericRepository<Loan> _loanRepository;
    private readonly IProductRepository _productRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateLoanCommand> _validator;

    public CreateLoanCommandHandler(IGenericRepository<Loan> LoanRepository, IMapper mapper, IValidator<CreateLoanCommand> validator, IClientRepository clientRepository, IProductRepository productRepository)
    {
      _loanRepository = LoanRepository;
      _mapper = mapper;
      _validator = validator;
      _clientRepository = clientRepository;
      _productRepository = productRepository;
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

      var loanEntity = _mapper.Map<Loan>(req);
      loanEntity.LoanBalance = req.LoanAmount;

      var Loan = await _loanRepository.AddAsync(loanEntity);

      var product = await _productRepository.AddAsync(new Product()
      {
        IsLoan = true,
        ClientId = req.ClientId,
        LoanId = Loan.Id,
        ProductTypeId = 1 //TODO: ADD THIS TO ALL CRUD OPERATIONS, ALSO ADD EF CORE SEED SCOPE TO CREATE PRODUCT TYPES 
      });

      Loan.ProductId = product.Id;

      await _loanRepository.Update(Loan);

      return _mapper.Map<LoanDTO>(Loan);
    }
  }
}
