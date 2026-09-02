using FluentValidation;
using Inventory.Application.DTOs.Supplier;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Queries.GetAllSupplier
{
    public class GetAllSupplierValidator: AbstractValidator<GetAllSupplierQuery>
    {
        public GetAllSupplierValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(x => x.SortBy)
                .Must(BeValidSortField)
                .WithMessage("SortBy debe ser: Nombre o Fecha de Creación");
        }
        private static bool BeValidSortField(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "name" => true,
                "companyName" => true,
                _ => false
            };
        }
    }
}
