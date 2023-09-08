using AutoMapper;
using BhdBankClone.Core.Application.DTOs.Transactions;
using BhdBankClone.Core.Application.Features.CreditCards.Queries;
using BhdBankClone.Core.Application.Interfaces;
using BhdBankClone.Core.Application.Interfaces.Repositories;
using BhdBankClone.Core.Application.Wrappers;
using BhdBankClone.Core.Domain;
using MediatR;

namespace BhdBankClone.Core.Application.Features.CreditCardResponseQuerys.Queries
{
  public class GetAllCreditCardsQuery : IRequest<Response<IEnumerable<CreditCardResponseQuery>>>
  {
  }

  internal class GetAllCreditCardsQueryHandler : IRequestHandler<GetAllCreditCardsQuery, Response<IEnumerable<CreditCardResponseQuery>>>
  {
    private readonly IGenericRepository<CreditCard> _repository;
    private readonly IBasicUserExtraAccountService _basicUserExtraAccountService;
    private readonly ITransactionRepository _transactionRepository;
    private readonly IMapper _mapper;

    public GetAllCreditCardsQueryHandler(IGenericRepository<CreditCard> repository, IMapper mapper, IBasicUserExtraAccountService basicUserExtraAccountService, ITransactionRepository transactionRepository)
    {
      _repository = repository;
      _mapper = mapper;
      _basicUserExtraAccountService = basicUserExtraAccountService;
      _transactionRepository = transactionRepository;
    }

    public async Task<Response<IEnumerable<CreditCardResponseQuery>>> Handle(GetAllCreditCardsQuery request, CancellationToken cancellationToken)
    {
      var parameters = new List<string>
      {
        "Client",
        //"Product",
        "Transactions"
      };

      var debitCards = await _repository.GetAllWithIncludeAsync(parameters);
      var mappedCards = _mapper.Map<IEnumerable<CreditCardResponseQuery>>(debitCards);
      var transactions = _transactionRepository.GetQueryable();

      foreach (var card in mappedCards)
      {
        if (card?.Client?.UserId != null)
        {
          var user = await _basicUserExtraAccountService.GetBasicUserByIdAsync(card.Client.UserId);

          if (user != null)
          {
            card.Client.FirstName = user.FirstName;
            card.Client.LastName = user.LastName;
          }
        }

        card.TransactionsAsSource = _mapper.
           Map<List<TransactionDTO>>(transactions.Where(t => t.SourceCreditCardId == card.Id).ToList());

        card.TransactionsAsDestination = _mapper.
        Map<List<TransactionDTO>>(transactions.Where(t => t.DestinationCreditCardId == card.Id).ToList());
      }


      return new Response<IEnumerable<CreditCardResponseQuery>>(mappedCards);
    }
  }
}
