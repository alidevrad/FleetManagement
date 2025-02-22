using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class DeactivateVehicleCommandValidator : AbstractValidator<DeactivateVehicleCommand>
{
    public DeactivateVehicleCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");
    }
}