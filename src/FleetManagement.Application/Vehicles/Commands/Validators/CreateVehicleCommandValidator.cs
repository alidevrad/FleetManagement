using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator()
    {
        RuleFor(v => v.VehicleTypeId)
            .GreaterThan(0)
            .WithMessage("Vehicle Type ID must be a valid positive number.");

        RuleFor(v => v.Manufacturer)
            .NotEmpty().WithMessage("Manufacturer is required.")
            .MaximumLength(100).WithMessage("Manufacturer must be at most 100 characters.");

        RuleFor(v => v.LicensePlateNumber)
            .NotEmpty().WithMessage("License Plate Number is required.")
            .MaximumLength(50).WithMessage("License Plate Number must be at most 50 characters.");

        RuleFor(v => v.ModelYear)
            .GreaterThan(1900).WithMessage("Model year must be after 1900.");

        RuleFor(v => v.Color)
            .NotEmpty().WithMessage("Color is required.")
            .MaximumLength(50).WithMessage("Color must be at most 50 characters.");

        RuleFor(v => v.LicensePlateImageUrl)
            .MaximumLength(500).WithMessage("License Plate Image URL must be at most 500 characters.")
            .Must(uri => string.IsNullOrEmpty(uri) || Uri.IsWellFormedUriString(uri, UriKind.Absolute))
            .WithMessage("License Plate Image URL must be a valid absolute URL.");
    }
}
