using AutoMapper;
using BhdBankClone.Core.Application.Features.CreditCards.Queries;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Queries
{
  public class GetAllDebitCardsQuery : IRequest<Response<IEnumerable<DebitCardResponseQuery>>>
  {
  }

  internal class GetAllDebitCardsQueryHandler : IRequestHandler<GetAllDebitCardsQuery, Response<IEnumerable<DebitCardResponseQuery>>>
  {
    private readonly IGenericRepository<DebitCard> _repository;
    private readonly IMapper _mapper;

    public GetAllDebitCardsQueryHandler(IGenericRepository<DebitCard> repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<DebitCardResponseQuery>>> Handle(GetAllDebitCardsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        //"Product",
        "Account",
      };

      var debitCards = await _repository.GetAllWithIncludeAsync(parameters);

      var cardMapped = _mapper.Map<IEnumerable<DebitCardResponseQuery>>(debitCards);
      
      return new Response<IEnumerable<DebitCardResponseQuery>>(cardMapped);
    }
  }  
}
