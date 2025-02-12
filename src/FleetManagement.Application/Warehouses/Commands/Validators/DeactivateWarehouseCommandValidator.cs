using FleetManagement.Application.Contract.Warehouses.Commands;
using FluentValidation;

namespace FleetManagement.Application.Warehouses.Commands.Validators;

public class DeactivateWarehouseCommandValidator : AbstractValidator<DeactivateWarehouseCommand>
{
    public DeactivateWarehouseCommandValidator()
    {
        RuleFor(w => w.Id)
            .GreaterThan(0).WithMessage("Invalid warehouse ID.");
    }
}