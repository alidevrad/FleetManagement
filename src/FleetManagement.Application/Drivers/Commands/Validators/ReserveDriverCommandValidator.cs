using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class ReserveDriverCommandValidator : AbstractValidator<ReserveDriverCommand>
{
    public ReserveDriverCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid driver ID.");
    }
}