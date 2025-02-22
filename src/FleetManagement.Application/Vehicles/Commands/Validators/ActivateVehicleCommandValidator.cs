using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;


public class ActivateVehicleCommandValidator : AbstractValidator<ActivateVehicleCommand>
{
    public ActivateVehicleCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");
    }
}
