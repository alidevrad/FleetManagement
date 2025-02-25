using FleetManagement.Application.Common.Validators;
using FleetManagement.Application.Contract.Customers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Customers.Commands.Validators;

public class UpdateBranchCommandValidator : AbstractValidator<UpdateBranchCommand>
{
    public UpdateBranchCommandValidator()
    {
        RuleFor(b => b.CustomerId)
            .GreaterThan(0).WithMessage("Invalid customer ID.");

        RuleFor(b => b.BranchId)
            .GreaterThan(0).WithMessage("Invalid branch ID.");

        RuleFor(b => b.Name)
            .NotEmpty().WithMessage("Branch name is required.")
            .MaximumLength(200).WithMessage("Branch name must be at most 200 characters.");

        RuleFor(b => b.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

        RuleFor(b => b.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");

        RuleFor(b => b.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(255).WithMessage("Address must be at most 255 characters.");

        RuleFor(b => b.AgentFullName)
            .NotEmpty().WithMessage("Agent full name is required.")
            .MaximumLength(200).WithMessage("Agent full name must be at most 200 characters.");

        RuleFor(d => d.AgentPhoneNumber)
         .NotNull().WithMessage("Agent's phone number is required.")
         .SetValidator(new PhoneNumberValidator());
    }
}
