using BhdBankClone.Core.Application.Features.BankAccountTypes.Command;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.BankAccounts
{
  public class CreateBankAccountTypeValidator : AbstractValidator<CreateBankAccountTypeCommand>
  {
    public CreateBankAccountTypeValidator()
    {
      RuleFor(p => p.Description)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull()
          .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
  }
}
