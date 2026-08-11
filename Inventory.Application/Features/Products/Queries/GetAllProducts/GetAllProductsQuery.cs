using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Product;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery
    : PaginationRequest,
      IRequest<Result<PagedResult<ProductDto>>>
{
    public string? Search { get; set; }
    public int? CategoryId { get; set; }
    public int? SupplierId { get; set; }
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public int? MinStock { get; set; }
    public int? MaxStock { get; set; }
    public string SortBy { get; set; } = "name";
    public bool Descending { get; set; }
}
