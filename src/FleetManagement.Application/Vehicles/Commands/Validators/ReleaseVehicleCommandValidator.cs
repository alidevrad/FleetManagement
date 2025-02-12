using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class ReleaseVehicleCommandValidator : AbstractValidator<ReleaseVehicleCommand>
{
    public ReleaseVehicleCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");
    }
}
