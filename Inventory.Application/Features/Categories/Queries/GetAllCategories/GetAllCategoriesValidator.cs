using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesValidator : AbstractValidator<GetAllCategoriesQuery>
    {
        public GetAllCategoriesValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(x => x.SortBy)
                .Must(BeValidSortField)
                .WithMessage("SortBy debe ser: Nombre, Descripción o Fecha de Creación");
        }
        private static bool BeValidSortField(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "name" => true,
                "description" => true,
                "createdat" => true,
                _ => false
            };
        }
    }
}
