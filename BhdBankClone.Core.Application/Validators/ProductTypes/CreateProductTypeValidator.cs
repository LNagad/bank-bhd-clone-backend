using BhdBankClone.Core.Application.Features.ProductTypes.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.ProductTypes
{
  public class CreateProductTypeValidator : AbstractValidator<CreateProductTypeCommand>
  {
    public CreateProductTypeValidator()
    {
      RuleFor(p => p.Description)
          .NotNull().WithMessage("Description is required")
          .NotEmpty().WithMessage("Description is required");
    }
  }
}
