using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class ReserveVehicleCommandValidator : AbstractValidator<ReserveVehicleCommand>
{
    public ReserveVehicleCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");

        RuleFor(d => d.Start)
            .LessThan(d => d.End).WithMessage("Start date must be before end date.")
            .GreaterThan(DateTime.UtcNow).WithMessage("Start date must be in the future.");

        RuleFor(d => d.End)
            .GreaterThan(DateTime.UtcNow).WithMessage("End date must be in the future.");
    }
}

