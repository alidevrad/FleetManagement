using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class DeleteVehicleCommandValidator : AbstractValidator<DeleteVehicleCommand>
{
    public DeleteVehicleCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");
    }
}
