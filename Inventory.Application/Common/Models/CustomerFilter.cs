using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Common.Models
{
    public class CustomerFilter : PaginationRequest
    {
        public string? Search { get; set; }
        public string? FullName { get; set; }
        public string? Dni { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string SortBy { get; set; } = "Name";
        public bool Descending { get; set; }
    }
}
