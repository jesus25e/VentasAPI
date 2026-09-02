using Inventory.Application.Common.Models;
using Inventory.Application.DTOs.Supplier;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Supplier.Queries.GetAllSupplier
{
    public class GetAllSupplierQuery : PaginationRequest, IRequest<Result<PagedResult<SupplierDto>>>
    {
        public string? Search { get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public int? Phone { get; set; }
        public string? Address { get; set; }
        public string SortBy { get; set; } = "name";
        public bool Descending { get; set; }
        
    }
}
