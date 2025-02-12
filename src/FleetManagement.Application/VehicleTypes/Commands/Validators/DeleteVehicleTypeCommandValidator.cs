using FleetManagement.Application.Contract.VehicleTypes.Commands;
using FluentValidation;

namespace FleetManagement.Application.VehicleTypes.Commands.Validators;

public class DeleteVehicleTypeCommandValidator : AbstractValidator<DeleteVehicleTypeCommand>
{
    public DeleteVehicleTypeCommandValidator()
    {
        RuleFor(w => w.Id)
           .GreaterThan(0).WithMessage("Invalid VehicleType ID.");
    }
}
