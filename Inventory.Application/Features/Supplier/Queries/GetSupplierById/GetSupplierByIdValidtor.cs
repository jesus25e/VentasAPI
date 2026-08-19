using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Queries.GetSupplierById
{
    public class GetSupplierByIdValidtor:AbstractValidator <GetSupplierByIdQuery>
    {
        public GetSupplierByIdValidtor() {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El Id es obligatorio");
        }
    }
}
