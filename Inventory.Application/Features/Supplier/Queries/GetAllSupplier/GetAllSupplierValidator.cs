using FluentValidation;
using Inventory.Application.DTOs.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Queries.GetAllSupplier
{
    public class GetAllSupplierValidator: AbstractValidator<SupplierDto>
    {
        public GetAllSupplierValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre del proveedor es obligatorio")
                .MaximumLength(100).WithMessage("El nombre del proveedor no puede exceder los 100 caracteres");

            RuleFor(x => x.CompanyName)
                .MaximumLength(100).WithMessage("El nombre de la empresa no puede exceder los 100 caracteres");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono del proveedor es obligatorio")
                .Matches(@"^\d{9}$").WithMessage("El teléfono del proveedor debe tener 9 dígitos");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("La dirección del proveedor no puede exceder los 200 caracteres");
        }
    }
}
