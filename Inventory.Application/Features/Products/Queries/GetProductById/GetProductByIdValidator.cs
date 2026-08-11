using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdValidator: AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdValidator()
        {
            RuleFor(x => x.Id)
                    .NotEmpty().WithMessage("El Id del producto es obligatorio");
        }
    }
}
