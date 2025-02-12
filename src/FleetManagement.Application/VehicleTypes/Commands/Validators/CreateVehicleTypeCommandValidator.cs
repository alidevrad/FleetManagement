using FleetManagement.Application.Contract.VehicleTypes.Commands;
using FluentValidation;

namespace FleetManagement.Application.VehicleTypes.Commands.Validators;

public class CreateVehicleTypeCommandValidator : AbstractValidator<CreateVehicleTypeCommand>
{
    public CreateVehicleTypeCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Vehicle type name is required.")
            .MaximumLength(100).WithMessage("Vehicle type name must be at most 100 characters.");

        RuleFor(v => v.Category)
            .IsInEnum().WithMessage("Invalid vehicle category.");

        RuleFor(v => v.MaxWeightCapacity)
            .GreaterThan(0).WithMessage("Max weight capacity must be greater than zero.");

        RuleFor(v => v.MaxVolumeCapacity)
            .GreaterThan(0).WithMessage("Max volume capacity must be greater than zero.");

        RuleFor(v => v.FuelType)
            .IsInEnum().WithMessage("Invalid fuel type.");

        RuleFor(v => v.AverageFuelConsumption)
            .GreaterThanOrEqualTo(0).WithMessage("Average fuel consumption cannot be negative.");

        RuleFor(v => v.RequiredLicenseType)
            .NotEmpty().WithMessage("Required license type is required.")
            .MaximumLength(10).WithMessage("License type must be at most 10 characters.");

        RuleFor(v => v.MaxSpeedLimit)
            .GreaterThan(0).WithMessage("Max speed limit must be greater than zero.");

        RuleFor(v => v.NumberOfWheels)
            .GreaterThan(0).WithMessage("Number of wheels must be greater than zero.");
    }
}

