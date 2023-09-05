using AutoMapper;
using BhdBankClone.Core.Application.DTOs.ProductTypes;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using FluentValidation;
using MediatR;

namespace BhdBankClone.Core.Application.Features.ProductTypes.Commands
{
  public class CreateProductTypeCommand : IRequest<Response<ProductTypeDTO>>
  {
    public required string Description { get; set; }
  }
  internal class CreateProductTypeCommandHandler : IRequestHandler<CreateProductTypeCommand, Response<ProductTypeDTO>>
  {
    private readonly IGenericRepository<ProductType> _productTypeRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateProductTypeCommand> _validator;

    public CreateProductTypeCommandHandler(IGenericRepository<ProductType> productTypeRepository, IMapper mapper, IValidator<CreateProductTypeCommand> validator)
    {
      _productTypeRepository = productTypeRepository;
      _mapper = mapper;
      _validator = validator;
    }

    public async Task<Response<ProductTypeDTO>> Handle(CreateProductTypeCommand request, CancellationToken cancellationToken)
    {
      var validationResult = await _validator.ValidateAsync(request);

      if (!validationResult.IsValid)
      {
        var validationErrors = validationResult.Errors.Select(error => error.ErrorMessage);
        throw new ApiException(validationErrors);
      }

      return new Response<ProductTypeDTO>() { Data = await CreateProductTypeAsync(request), Succeeded = true, Errors = null };
    }

    private async Task<ProductTypeDTO> CreateProductTypeAsync(CreateProductTypeCommand req)
    {
      // TODO: Add validation for product type description so that it is unique
      var productType = await _productTypeRepository.AddAsync(_mapper.Map<ProductType>(req));

      return _mapper.Map<ProductTypeDTO>(productType);
    }
  }
}
