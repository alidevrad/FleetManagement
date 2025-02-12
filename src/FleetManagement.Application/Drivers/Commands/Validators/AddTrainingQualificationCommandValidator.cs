using FleetManagement.Application.Contract.Drivers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Drivers.Commands.Validators;

public class AddTrainingQualificationCommandValidator : AbstractValidator<AddTrainingQualificationCommand>
{
    public AddTrainingQualificationCommandValidator()
    {
        RuleFor(c => c.DriverId)
            .GreaterThan(0).WithMessage("Driver ID must be greater than zero.");

        RuleFor(c => c.QualificationName)
            .NotEmpty().WithMessage("Qualification name is required.")
            .MaximumLength(150).WithMessage("Qualification name must be at most 150 characters.");

        RuleFor(c => c.ObtainedDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Obtained date cannot be in the future.")
            .When(c => c.ObtainedDate.HasValue);

        RuleFor(c => c.ExpirationDate)
            .GreaterThan(c => c.ObtainedDate)
            .WithMessage("Expiration date must be later than the obtained date.")
            .When(c => c.ObtainedDate.HasValue && c.ExpirationDate.HasValue);
    }
}