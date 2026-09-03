using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Product
{
    public class CreateProduct
    {
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int stock { get; init; }
        public int StockMin { get; init; } = 5;
        public int? CategoryId { get; init; }
        public int? SupplierId { get; init; }
    }
}
