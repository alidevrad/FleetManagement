using FleetManagement.Application.Contract.Customers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Customers.Commands.Validators;

public class DeactivateBranchCommandValidator : AbstractValidator<DeactivateBranchCommand>
{
    public DeactivateBranchCommandValidator()
    {
        RuleFor(b => b.CustomerId)
            .GreaterThan(0).WithMessage("Invalid customer ID.");

        RuleFor(b => b.BranchId)
            .GreaterThan(0).WithMessage("Invalid branch ID.");
    }
}
