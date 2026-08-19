using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.DeleteSupplier
{
    public class DeleteSupplierValidator: AbstractValidator<DeleteSupplierCommand>
    {
        public DeleteSupplierValidator() {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}
