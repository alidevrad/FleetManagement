using FleetManagement.Application.Common.Validators;
using FleetManagement.Application.Contract.Warehouses.Commands;
using FluentValidation;

namespace FleetManagement.Application.Warehouses.Commands.Validators;

public class UpdateWarehouseCommandValidator : AbstractValidator<UpdateWarehouseCommand>
{
    public UpdateWarehouseCommandValidator()
    {
        RuleFor(w => w.Id)
            .GreaterThan(0).WithMessage("Invalid warehouse ID.");

        RuleFor(w => w.Name)
            .NotEmpty().WithMessage("Warehouse name is required.")
            .MaximumLength(100).WithMessage("Warehouse name must be at most 100 characters.");

        RuleFor(w => w.Street)
            .NotEmpty().WithMessage("Street address is required.")
            .MaximumLength(200).WithMessage("Street address must be at most 200 characters.");

        RuleFor(w => w.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City must be at most 100 characters.");

        RuleFor(w => w.State)
            .NotEmpty().WithMessage("State is required.")
            .MaximumLength(100).WithMessage("State must be at most 100 characters.");

        RuleFor(w => w.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .MaximumLength(20).WithMessage("Postal code must be at most 20 characters.");

        RuleFor(w => w.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100).WithMessage("Country must be at most 100 characters.");

        RuleFor(w => w.PhoneNumber)
            .NotNull().WithMessage("Phone number is required.")
            .SetValidator(new PhoneNumberValidator());

        RuleFor(w => w.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(150).WithMessage("Email must be at most 150 characters.");

        RuleFor(w => w.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

        RuleFor(w => w.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");
    }
}
