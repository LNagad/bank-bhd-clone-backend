using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Products.Queries.GetAllProducts
{
  public class GetAllProductsQuery : IRequest<Response<IEnumerable<ProductDTO>>>
  {
  }

  internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<ProductDTO>>>
  {
    private readonly IGenericRepository<Product> _repository;
    private readonly IMapper _mapper;


    public GetAllProductsQueryHandler(IGenericRepository<Product> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ProductDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string> { "Client", "ProductType", "Account", "Loan", "CreditCard", "DebitCard" };

      var products = await  _repository.GetAllWithIncludeAsync(parameters);
         
      return new Response<IEnumerable<ProductDTO>>( _mapper.Map<IEnumerable<ProductDTO>>(products) );
    }
  }
}
