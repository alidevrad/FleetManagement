using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class ReleaseDriverFromReservationCommandValidator : AbstractValidator<ReleaseDriverFromReservationCommand>
{
    public ReleaseDriverFromReservationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Invalid driver Id");

        RuleFor(x => x.ReservationId).GreaterThan(0).WithMessage("Reservation ID must be greater than zero.");
    }
}