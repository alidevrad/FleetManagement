using FleetManagement.Application.Contract.Customers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Customers.Commands.Validators;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("Invalid customer ID.");
    }
}
