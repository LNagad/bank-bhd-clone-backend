using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.ProductTypes.Commands
{
  public class CreateProductCommand : IRequest<Response<ProductDTO>>
  {
    public int? ProductTypeId { get; set; }

    public int? ClientId { get; set; }

    public bool? IsAccount { get; set; }

    public bool? IsLoan { get; set; }

    public bool? IsCreditCard { get; set; }

    public bool? IsDebitCard { get; set; }

    public int? AccountId { get; set; }

    public int? LoanId { get; set; }

    public int? CreditCardId { get; set; }

    public int? DebitCardId { get; set; }
  }
  public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<ProductDTO>>
  {
    private readonly IGenericRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IGenericRepository<Product> productRepository, IMapper mapper, IValidator<CreateProductCommand> validator)
    {
      _productRepository = productRepository;
      _mapper = mapper;
      _validator = validator;
    }

    public async Task<Response<ProductDTO>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<ProductDTO>() { Data = await CreateProductAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<ProductDTO> CreateProductAsync(CreateProductCommand req)
    {
      //if (req.IsAccount     == true && req.AccountId    == null)throw new ApiException("Account Id is required");
      //if (req.IsLoan        == true && req.LoanId       == null)throw new ApiException("Loan Id is required");
      //if (req.IsCreditCard  == true && req.CreditCardId == null)throw new ApiException("Credit Card Id is required");
      //if (req.IsDebitCard   == true && req.DebitCardId  == null)throw new ApiException("Debit Card Id is required");

      //TODO: Check if any of the Ids are valid by checking if exists in the database

      var product = await _productRepository.AddAsync(_mapper.Map<Product>(req));

      return _mapper.Map<ProductDTO>(product);
    }
  }
}
