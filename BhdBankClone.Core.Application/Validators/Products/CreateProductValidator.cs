using BhdBankClone.Core.Application.Features.ProductTypes.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.Products
{
  internal class CreateProductValidator : AbstractValidator<CreateProductCommand>
  {
    public CreateProductValidator()
    {
      RuleFor(p => p.ClientId)
        .NotNull().WithMessage("Client Id is required")
        .NotEmpty().WithMessage("Client Id is required");

      RuleFor(p => p.ProductTypeId)
        .NotNull().WithMessage("Product type Id is required")
        .NotEmpty().WithMessage("Product type Id is required");

      RuleFor(req => req)
        .Custom((req, context) => {
          if (req.IsAccount == true && req.AccountId == null) context.AddFailure("Account Id is required");
          if (req.IsLoan == true && req.LoanId == null) context.AddFailure("Loan Id is required");
          if (req.IsCreditCard == true && req.CreditCardId == null) context.AddFailure("Credit Card Id is required");
          if (req.IsDebitCard == true && req.DebitCardId == null) context.AddFailure("Debit Card Id is required");
        });
    }
  }
}
