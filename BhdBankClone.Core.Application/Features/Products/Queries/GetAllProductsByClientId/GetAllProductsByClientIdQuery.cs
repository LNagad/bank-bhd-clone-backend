using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Products;
using BhdBankClone.Core.Application.Exceptions;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;
using System.Net;

namespace BhdBankClone.Core.Application.Features.Products.Queries.GetAllProductsByClientId
{
  public class GetAllProductsByClientIdQuery : IRequest<Response<IEnumerable<ProductDTO>>>
  {
    public int ClientId { get; set; }
  }

  internal class GetAllProductsByClientIdHandler : IRequestHandler<GetAllProductsByClientIdQuery, Response<IEnumerable<ProductDTO>>>
  {
    private readonly IProductRepository _repository;
    private readonly IClientRepository _clientRepo;
    private readonly IMapper _mapper;

    public GetAllProductsByClientIdHandler(IProductRepository repository, IClientRepository clientRepo, IMapper mapper)
    {
      _repository = repository;
      _clientRepo = clientRepo;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<ProductDTO>>> Handle(GetAllProductsByClientIdQuery request, CancellationToken cancellationToken)
    {
      if (request.ClientId <= 0) throw new ApiException("Client Id is required", (int)HttpStatusCode.BadRequest);
      
      var client = await _clientRepo.GetByIdAsync(request.ClientId);

      if (client == null) throw new ApiException("Client not found", (int)HttpStatusCode.NotFound);

      var parameters = new List<string> { "Client", "ProductType", "Account", "Loan", "CreditCard", "DebitCard" };

      var products = _repository.GetAllProductByClientIdWithInclude(request.ClientId, parameters);
    
      return new Response<IEnumerable<ProductDTO>>( _mapper.Map<IEnumerable<ProductDTO>>(products) );
    }
  }
}
