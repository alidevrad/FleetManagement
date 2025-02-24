using FleetManagement.Application.Contract.Users.Commands;
using FluentValidation;

namespace FleetManagement.Application.Users.Commands.Validators;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(l => l.UserName)
            .NotEmpty().WithMessage("Username is required.");

        RuleFor(l => l.Password)
            .NotEmpty().WithMessage("Password is required.");
    }
}

