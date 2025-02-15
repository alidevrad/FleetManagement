using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class ReserveDriverCommandValidator : AbstractValidator<ReserveDriverCommand>
{
    public ReserveDriverCommandValidator()
    {
        RuleFor(d => d.Id)
            .GreaterThan(0).WithMessage("Invalid driver ID.");

        RuleFor(d => d.Start)
            .LessThan(d => d.End).WithMessage("Start date must be before end date.")
            .GreaterThan(DateTime.UtcNow).WithMessage("Start date must be in the future.");

        RuleFor(d => d.End)
            .GreaterThan(DateTime.UtcNow).WithMessage("End date must be in the future.");
    }
}