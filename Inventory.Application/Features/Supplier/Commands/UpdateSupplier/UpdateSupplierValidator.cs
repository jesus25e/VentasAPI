using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.UpdateSupplier
{
    public class UpdateSupplierValidator: AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierValidator() {
            RuleFor(x => x.Id)
                .GreaterThan(0);

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.CompanyName)
                .MaximumLength(150);

            RuleFor(x => x.Phone)
                .NotEmpty()
                .MaximumLength(12);

            RuleFor(x => x.Address)
                .MaximumLength(500);
        }
    }
}
