using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Models
{
    public class ProductFilter:PaginationRequest
    {
        public string? Search { get; set; }
        public int? CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinStock { get; set;  }
        public int? MaxStock { get; set; }
        public string? SortBy { get; set; } = "Name";
        public bool Descending { get; set; }
    }
}
