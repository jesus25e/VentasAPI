using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Models
{
    public class SupplierFilter:PaginationRequest
    {
        public string? Search {  get; set; }
        public string? Name { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public int? Phone { get; set; }
        public string SortBy { get; set; } = "Name";
        public bool Descending { get; set; }

    }
}
