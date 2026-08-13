using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryValidator: AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator() 
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("El nombre es obligatorio.")
                .MaximumLength(100)
                .WithMessage("El nombre no puede exceder los 100 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(200)
                .WithMessage("La descripción no puede exceder los 200 caracteres.");
        }
    }
}
