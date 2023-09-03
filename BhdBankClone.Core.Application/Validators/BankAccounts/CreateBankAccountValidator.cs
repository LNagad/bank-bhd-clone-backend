using BhdBankClone.Core.Application.Features.BankAccounts.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.BankAccounts
{
  public class CreateBankAccountValidator : AbstractValidator<CreateBankAccountCommand>
  {

    public CreateBankAccountValidator()
    {
      RuleFor(p => p.AccountTypeId)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

      RuleFor(p => p.ClientId)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

      RuleFor(p => p.CurrentBalance)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .GreaterThan(0);

      RuleFor(req => req)
       .Custom((req, context) => {
         if (req.DebitCardId != null)
         {
           if (req.DebitCardId <= 0) context.AddFailure("Debit Card Id is required");
         }
       });
    }
  }
}
