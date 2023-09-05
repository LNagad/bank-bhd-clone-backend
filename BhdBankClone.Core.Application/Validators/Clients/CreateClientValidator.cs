using BhdBankClone.Core.Application.Features.Clients.Commands;
using FluentValidation;

namespace BhdBankClone.Core.Application.Validators.Clients
{
  public class CreateClientValidator : AbstractValidator<CreateClientCommand>
  {
    public CreateClientValidator()
    {
      RuleFor(x => x.IdentityCard)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .MinimumLength(11).WithMessage("{PropertyName} must be at least 11 characters.")
        .Matches(@"^(402|001)\d{8}$").WithMessage("{PropertyName} must start with '402' or '001' and be followed by 8 digits.");

      RuleFor(x => x.UserId)
        .NotEmpty().WithMessage("{PropertyName} is required.");

      RuleFor(x => x.ClientTypeId)
        .NotEmpty().WithMessage("{PropertyName} is required.");

    }
  }
}
