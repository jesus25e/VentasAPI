using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator() { 
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("El Id del producto debe ser un mayor que 0.");
        }
    }
}
