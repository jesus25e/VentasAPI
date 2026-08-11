using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductValidator : AbstractValidator<GetAllProductsQuery>
    {
        public GetAllProductValidator()
        {
            RuleFor(x => x.Page)
                .GreaterThanOrEqualTo(1);

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100);

            RuleFor(x => x.MinPrice)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MinPrice.HasValue);

            RuleFor(x => x.MaxPrice)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MaxPrice.HasValue);

            RuleFor(x => x)
                .Must(x =>
                    !x.MinPrice.HasValue ||
                    !x.MaxPrice.HasValue ||
                    x.MinPrice <= x.MaxPrice)
                .WithMessage("MinPrice no puede ser mayor que MaxPrice.");

            RuleFor(x => x.MinStock)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MinStock.HasValue);

            RuleFor(x => x.MaxStock)
                .GreaterThanOrEqualTo(0)
                .When(x => x.MaxStock.HasValue);

            RuleFor(x => x)
                .Must(x =>
                    !x.MinStock.HasValue ||
                    !x.MaxStock.HasValue ||
                    x.MinStock <= x.MaxStock)
                .WithMessage("MinStock no puede ser mayor que MaxStock.");

            RuleFor(x => x.SortBy)
                .Must(BeValidSortField)
                .WithMessage("SotBy debe ser: name, price, stock o createdAt.");
        }

        private static bool BeValidSortField(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "name" => true,
                "price" => true,
                "stock" => true,
                "createdAt" => true,
                _ => false
            };
        }
    }
}
