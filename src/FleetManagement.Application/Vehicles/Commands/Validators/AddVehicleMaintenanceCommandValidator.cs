using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class AddVehicleMaintenanceCommandValidator : AbstractValidator<AddVehicleMaintenanceCommand>
{
    public AddVehicleMaintenanceCommandValidator()
    {
        RuleFor(v => v.VehicleId)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");

        RuleFor(v => v.Reason)
            .NotEmpty().WithMessage("Maintenance reason is required.")
            .MaximumLength(250).WithMessage("Maintenance reason must be at most 250 characters.");

        RuleFor(v => v.RepairDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Repair date cannot be in the future.");
    }
}
