using FleetManagement.Application.Common.Validators;
using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
{
    public CreateDriverCommandValidator()
    {
        RuleFor(d => d.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(100).WithMessage("First name must be at most 100 characters.");

        RuleFor(d => d.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(100).WithMessage("Last name must be at most 100 characters.");

        RuleFor(d => d.NativeLanguage)
            .NotEmpty().WithMessage("Native language is required.")
            .MaximumLength(100).WithMessage("Native language must be at most 100 characters.");

        RuleFor(d => d.Gender)
            .IsInEnum().WithMessage("Invalid gender value.");

        RuleFor(d => d.PhoneNumber)
            .NotNull().WithMessage("Phone number is required.")
            .SetValidator(new PhoneNumberValidator());

        RuleFor(d => d.Address)
            .MaximumLength(255).WithMessage("Address must be at most 255 characters.");

        RuleFor(d => d.DateOfBirth)
            .LessThan(DateTime.UtcNow).WithMessage("Date of birth must be in the past.");

        RuleFor(d => d.LicenseType)
            .NotEmpty().WithMessage("License type is required.")
            .MaximumLength(50).WithMessage("License type must be at most 50 characters.");

        RuleFor(d => d.LicenseIssueDate)
            .LessThan(d => d.LicenseExpirationDate).WithMessage("License issue date must be before expiration date.");

        RuleFor(d => d.LicenseExpirationDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("License expiration date must be in the future.");

        RuleFor(v => v.ImageUrl)
           .MaximumLength(500).WithMessage("Driver's Image URL must be at most 500 characters.")
           .Must(uri => string.IsNullOrEmpty(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
           .WithMessage("Driver's Image URL must be a valid absolute URL.");
    }
}
