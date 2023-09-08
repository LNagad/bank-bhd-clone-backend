using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Clients;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCards.Queries
{
  public class GetAllCreditCardsByClientIdQuery : IRequest<Response<IEnumerable<CreditCardResponseQuery>>>
  {
    public required int ClientId { get; set; }
  }

  internal class GetAllCreditCardsByClientIdQueryHandler : 
    IRequestHandler<GetAllCreditCardsByClientIdQuery, Response<IEnumerable<CreditCardResponseQuery>>>
  {
    private readonly ICreditCardRepository _repository;
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllCreditCardsByClientIdQueryHandler(ICreditCardRepository repository, IMapper mapper, IBasicUserExtraAccountService basicUserExtraAccountService, ITransactionRepository transactionRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _basicUserExtraAccountService = basicUserExtraAccountService;
      _transactionRepository = transactionRepository;
    }

    public async Task<Response<IEnumerable<CreditCardResponseQuery>>> Handle(GetAllCreditCardsByClientIdQuery request, 
      CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        //"Product",
        "Transactions"
      };

      var creditCards = _repository.GetCreditCardsWithIncludeByClientIdEnumerable(request.ClientId, parameters);

      var mappedCards = _mapper.Map<IEnumerable<CreditCardResponseQuery>>(creditCards);

      string userId = creditCards.FirstOrDefault( p => p.Client.UserId != null  ).Client.UserId;

      if (userId != null)
      {
        var user = await _basicUserExtraAccountService.GetBasicUserByIdAsync(userId);

        if (user != null)
        {
          foreach (var card in mappedCards)
          {
            var transactions = _transactionRepository.GetQueryable();

            if (card.Client == null) card.Client = new ClientDTO() { IdentityCard = null };

            card.Client.FirstName = user.FirstName;
            card.Client.LastName = user.LastName;

            card.TransactionsAsSource = _mapper.
            Map<List<TransactionDTO>>(transactions.Where(t => t.SourceCreditCardId == card.Id).ToList());

            card.TransactionsAsDestination = _mapper.
            Map<List<TransactionDTO>>(transactions.Where(t => t.DestinationCreditCardId == card.Id).ToList());
          }
        }
      }

      return new Response<IEnumerable<CreditCardResponseQuery>>(mappedCards);
    }
  }
}
