using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class UpdateVehicleMaintenanceCommandValidator : AbstractValidator<UpdateVehicleMaintenanceCommand>
{
    public UpdateVehicleMaintenanceCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");

        RuleFor(v => v.VehicleMaintenanceId)
           .GreaterThan(0).WithMessage("Invalid vehicle ID.");

        RuleFor(v => v.Reason)
            .NotEmpty().WithMessage("Maintenance reason is required.")
            .MaximumLength(250).WithMessage("Maintenance reason must be at most 250 characters.");
    }
}
