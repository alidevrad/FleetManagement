using FleetManagement.Application.Contract.Customers.Commands;
using FluentValidation;

namespace FleetManagement.Application.Customers.Commands.Validators;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator()
    {
        RuleFor(c => c.Id)
            .GreaterThan(0).WithMessage("Invalid customer ID.");

        RuleFor(c => c.StoreName)
             .NotEmpty().WithMessage("Store name is required.")
             .MaximumLength(200).WithMessage("Store name must be at most 200 characters.");

        RuleFor(c => c.StoreOwnerName)
            .NotEmpty().WithMessage("Store owner name is required.")
            .MaximumLength(200).WithMessage("Store owner name must be at most 200 characters.");

        RuleFor(c => c.TaxNumber)
            .NotEmpty().WithMessage("Tax number is required.")
            .MaximumLength(50).WithMessage("Tax number must be at most 50 characters.");

        RuleFor(c => c.Latitude)
            .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

        RuleFor(c => c.Longitude)
            .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");

        RuleFor(c => c.Email)
            .EmailAddress().WithMessage("Invalid email format.")
            .MaximumLength(150).WithMessage("Email must be at most 150 characters.");
    }
}
