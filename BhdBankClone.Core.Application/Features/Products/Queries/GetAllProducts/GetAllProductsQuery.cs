using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.Products.Queries.GetAllProducts
{
  public class GetAllProductsQuery : IRequest<Response<List<Product>>>
  {
  }

  internal class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<List<Product>>>
  {
    private readonly IGenericRepository<Product> _repository;

    public GetAllProductsQueryHandler(IGenericRepository<Product> repository)
    {
      _repository = repository;
    }

    public async Task<Response<List<Product>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string> { "Client", "ProductType", "Account", "Loan", "CreditCard", "DebitCard" };

      var products = await  _repository.GetAllWithIncludeAsync(parameters);
         
      return new Response<List<Product>>(products);
    }
  }
}
