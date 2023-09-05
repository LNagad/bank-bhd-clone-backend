using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.Enums.BankSeeds;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Products.Commands
{
  public class CreateProductCommand : IRequest<Response<ProductDTO>>
  {
    public int ProductTypeId { get; set; }

    public int ClientId { get; set; }

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
    private readonly IGenericRepository<ProductType> _productTypeRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IGenericRepository<Product> productRepository, IMapper mapper, IValidator<CreateProductCommand> validator, IGenericRepository<ProductType> productTypeRepository)
    {
      _productRepository = productRepository;
      _mapper = mapper;
      _validator = validator;
      _productTypeRepository = productTypeRepository;
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
      var product = _mapper.Map<Product>(req);

      switch (req.ProductTypeId)
      {
        case (int)EProducts.CUENTA_AHORROS:
        case (int)EProducts.CUENTA_AHORROS_EMPRESARIAL:
        case (int)EProducts.TARJETA_DEBITO:
        case (int)EProducts.TARJETA_CREDITO:
        case (int)EProducts.PRESTAMO:
          var pType = _productTypeRepository.GetQueryable().FirstOrDefault(pt => pt.Description == ( (EProducts)req.ProductTypeId).ToString() );

          if (pType == null) throw new ApiException("Product type not found", 404);

          product.ProductTypeId = pType.Id;

          break;
        default:
          throw new ApiException("Invalid product type", 400);
      }

      var resp = await _productRepository.AddAsync(product);

      return _mapper.Map<ProductDTO>(resp);
    }
  }
}
