using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Models
{
    public class CategoryFilter: PaginationRequest
    {
        public string? Search { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string SortBy { get; set; } = "Name";
        public bool Descending { get; set; }
    }
}
