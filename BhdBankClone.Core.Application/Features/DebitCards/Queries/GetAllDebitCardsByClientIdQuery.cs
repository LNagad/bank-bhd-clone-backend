using AutoMapper;
using BhdBankClone.Core.Application.Features.CreditCards.Queries;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.DebitCards.Queries
{
  public class GetAllDebitCardsByClientIdQuery : IRequest<Response<IEnumerable<DebitCardResponseQuery>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllDebitCardsByClientIdQueryHandler : IRequestHandler<GetAllDebitCardsByClientIdQuery, Response<IEnumerable<DebitCardResponseQuery>>>
  {
    private readonly IDebitCardRepository _repository;
    private readonly IMapper _mapper;

    public GetAllDebitCardsByClientIdQueryHandler(IDebitCardRepository repository, IMapper mapper)
    {
      _repository = repository;
      _mapper = mapper;
    }

    public async Task<Response<IEnumerable<DebitCardResponseQuery>>> Handle(GetAllDebitCardsByClientIdQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        //"Product",
        "Account"
      };

      var debitCards = _repository.GetDebitCardsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      var cardMapped = _mapper.Map<IEnumerable<DebitCardResponseQuery>>(debitCards);

      return new Response<IEnumerable<DebitCardResponseQuery>>(cardMapped);
    }
  }
}
