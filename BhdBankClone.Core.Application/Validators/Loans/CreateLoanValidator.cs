using BhdBankClone.Core.Application.Features.Loans.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.Loans
{
  public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
  {
    public CreateLoanValidator()
    {
      RuleFor(p => p.LoanAmount)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull()
          .GreaterThan(0).WithMessage("{PropertyName} must be greater than $0.");

      RuleFor(p => p.ClientId)
          .NotEmpty().WithMessage("{PropertyName} is required.")
          .NotNull()
          .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.");
    }
  }
}
