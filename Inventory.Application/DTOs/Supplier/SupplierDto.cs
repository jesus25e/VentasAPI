using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Supplier
{
    public class SupplierDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string CompanyName { get; init; } = string.Empty;
        public string Phone {  get; init; } = string.Empty;
    }
}
