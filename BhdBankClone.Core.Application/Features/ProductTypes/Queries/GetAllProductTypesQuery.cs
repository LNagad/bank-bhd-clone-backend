using AutoMapper;
using BhdBankClone.Core.Application.DTOs.ProductTypes;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.ProductTypes.Queries
{
  public class GetAllProductTypesQuery : IRequest<Response<List<ProductTypeDTO>>>
  {

  }

  public class GetAllProductTypesQueryHandler : IRequestHandler<GetAllProductTypesQuery, Response<List<ProductTypeDTO>>>
  {
    private readonly IGenericRepository<ProductType> _productTypesRepository;
    private readonly IMapper _mapper;

    public GetAllProductTypesQueryHandler(IGenericRepository<ProductType> productTypesRepository, IMapper mapper)
    {
      _productTypesRepository = productTypesRepository;
      _mapper = mapper;
    }

    public async Task<Response<List<ProductTypeDTO>>> Handle(GetAllProductTypesQuery request, CancellationToken cancellationToken)
    {
      var productTypes = await _productTypesRepository.GetAllAsyncList();

      var productTypesDto = _mapper.Map<List<ProductTypeDTO>>(productTypes);

      return new Response<List<ProductTypeDTO>>(productTypesDto);
    }
  }
}
