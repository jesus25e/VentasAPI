using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(500);

            RuleFor(x => x.Price)
                .GreaterThan(0);

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.StockMin)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Ingrese un stockMin Valido.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0);

            RuleFor(x => x.SupplierId)
                .GreaterThan(0);
        }
    }
}
