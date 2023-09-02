using BhdBankClone.Core.Application.Features.DebitCards.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.DebitCards
{
  public class CreateDebitCardValidator : AbstractValidator<CreateDebitCardCommand>
  {
    public CreateDebitCardValidator()
    {
      RuleFor(p => p.ClientId)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull()
          .GreaterThan(0);

      RuleFor(p => p.AccountId)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull()
          .GreaterThan(0);
    }
  }
}
