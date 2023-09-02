using BhdBankClone.Core.Application.Features.CreditCards.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.CreditCards
{
  public class CreditCardValidator : AbstractValidator<CreateCreditCardCommand>
  {
    public CreditCardValidator()
    {
      RuleFor(p => p.CreditLimit).NotEmpty().WithMessage("{PropertyName} is required.");
      RuleFor(p => p.CreditLimit).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
      RuleFor(p => p.ClientId).NotEmpty().WithMessage("{PropertyName} is required.");
      RuleFor(p => p.ClientId).GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
    }
  }
}
