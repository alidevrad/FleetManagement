using FleetManagement.Application.Contract.Warehouses.Commands;
using FluentValidation;

namespace FleetManagement.Application.Warehouses.Commands.Validators;

public class DeleteWarehouseCommandValidator : AbstractValidator<DeleteWarehouseCommand>
{
    public DeleteWarehouseCommandValidator()
    {
        RuleFor(w => w.Id)
            .GreaterThan(0).WithMessage("Invalid warehouse ID.");
    }
}
