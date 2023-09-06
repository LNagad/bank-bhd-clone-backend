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

    }
  }
}
