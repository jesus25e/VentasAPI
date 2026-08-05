using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Auth.Commands.Register
{
    public class RegisterValidator: AbstractValidator<RegisterCommand>
    {
        public RegisterValidator() {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.LastName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.Password)
                .MinimumLength(8)
                .Matches("[A-Z]")
                .WithMessage("Debe contenet una mayúscula.")
                .Matches("[a-z]")
                .WithMessage("Debe contener una minúscula.")
                .Matches("[0-9]")
                .WithMessage("Debe contener un número.");
        }
    }
}
