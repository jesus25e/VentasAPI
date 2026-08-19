using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Commands.CreateSupplier
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierValidator() {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.CompanyName)
                .MaximumLength(150);

            RuleFor(x => x.Phone)
                .NotNull()
                .MaximumLength(12);

            RuleFor(x => x.Address)
                .MaximumLength(500);

        }
    }
}
