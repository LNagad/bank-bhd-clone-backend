using BhdBankClone.Core.Application.Features.Products.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BhdBankClone.Core.Application.Validators.TransactionValidation
{
  public class CreateTransactionValidator : AbstractValidator<CreateTransactionCommand>
  {
    public CreateTransactionValidator()
    {
     RuleFor( x => x.Amount )
       .NotEmpty().WithMessage( "{PropertyName} is required." )
       .NotNull()
       .GreaterThan( 0 );

      RuleFor( x => x.TransactionTypeId )
        .NotEmpty().WithMessage( "{PropertyName} is required." )
        .NotNull()
        .GreaterThan( 0 );

      RuleFor( x => x.ClientId )
        .NotEmpty().WithMessage( "{PropertyName} is required." )
        .NotNull()
        .GreaterThan( 0 );

      RuleFor(req => req)
       .Custom((req, context) => {
         if ( 
          (req.SourceAccountId > 0 && req.DestinationAccountId > 0) &&
          (req.SourceAccountId == req.DestinationAccountId)
         ) context.AddFailure("Cannot send transaction to same account");
         
         if (
         (req.SourceCreditCardId > 0 && req.DestinationCreditCardId > 0) &&
         (req.SourceCreditCardId == req.DestinationCreditCardId)
         ) context.AddFailure("Cannot send transaction to same credit card");         
       });

    }
  }
}
