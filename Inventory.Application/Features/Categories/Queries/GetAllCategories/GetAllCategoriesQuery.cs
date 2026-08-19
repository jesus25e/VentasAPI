using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Category;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : PaginationRequest, IRequest<Result<PagedResult<CategoryDto>>>
    {
        public string? Search { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string SortBy { get; set; } = "name";
        public bool Descending { get; set; }
    }
}
