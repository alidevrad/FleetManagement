using FleetManagement.Application.Contract.Customers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Customers.Commands.Validators;

public class RemovePhoneNumberCommandValidator : AbstractValidator<RemovePhoneNumberCommand>
{
    public RemovePhoneNumberCommandValidator()
    {
        RuleFor(p => p.CustomerId)
            .GreaterThan(0).WithMessage("Invalid customer ID.");

        RuleFor(p => p.Number)
            .NotEmpty().WithMessage("Phone number is required.");
    }
}
