using FleetManagement.Application.Contract.Vehicles.Commands;
using FluentValidation;

namespace FleetManagement.Application.Vehicles.Commands.Validators;

public class ReleaseVehicleFromReservationCommandValidator : AbstractValidator<ReleaseVehicleFromReservationCommand>
{
    public ReleaseVehicleFromReservationCommandValidator()
    {
        RuleFor(v => v.Id)
            .GreaterThan(0).WithMessage("Invalid vehicle ID.");

        RuleFor(x => x.ReservationId).GreaterThan(0).WithMessage("Reservation ID must be greater than zero.");
    }
}
