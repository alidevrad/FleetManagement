using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class ReleaseDriverCommandValidator : AbstractValidator<ReleaseDriverCommand>
{
    public ReleaseDriverCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid driver ID.");
    }
}