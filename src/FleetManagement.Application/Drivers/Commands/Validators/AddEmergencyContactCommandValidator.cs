using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class AddEmergencyContactCommandValidator : AbstractValidator<AddEmergencyContactCommand>
{
    public AddEmergencyContactCommandValidator()
    {
        RuleFor(c => c.DriverId)
            .GreaterThan(0).WithMessage("Driver ID must be greater than zero.");

        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Contact name is required.")
            .MaximumLength(100).WithMessage("Contact name must be at most 100 characters.");

        RuleFor(c => c.Relationship)
            .NotEmpty().WithMessage("Relationship is required.")
            .MaximumLength(50).WithMessage("Relationship must be at most 50 characters.");

        RuleFor(c => c.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");
    }
}