using FleetManagement.Domain.Common.BuildingBlocks;
using FluentValidation;

namespace FleetManagement.Application.Common.Validators;

public class PhoneNumberValidator : AbstractValidator<PhoneNumber>
{
    public PhoneNumberValidator()
    {
        RuleFor(p => p.CountryCode)
            .NotEmpty().WithMessage("Country code is required.")
            .Matches(@"^\+[1-9]\d{0,8}$")
            .WithMessage("Country code must be in the format '+[digits]' (e.g., +1, +44).");

        RuleFor(p => p.Number)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{6,20}$").WithMessage("Invalid phone number format.");

        RuleFor(p => p.Title)
            .NotEmpty().WithMessage("Phone number title is required.")
            .MaximumLength(100).WithMessage("Title must be at most 100 characters.");
    }
}
