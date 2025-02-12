using FleetManagement.Application.Contract.Customers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Customers.Commands.Validators;

public class RemoveBranchCommandValidator : AbstractValidator<RemoveBranchCommand>
{
    public RemoveBranchCommandValidator()
    {
        RuleFor(b => b.CustomerId)
            .GreaterThan(0).WithMessage("Invalid customer ID.");

        RuleFor(b => b.BranchId)
            .GreaterThan(0).WithMessage("Invalid branch ID.");
    }
}
