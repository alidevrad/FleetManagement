using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class DeactivateDriverCommandValidator : AbstractValidator<DeactivateDriverCommand>
{
    public DeactivateDriverCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid driver ID.");
    }
}