using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Product
{
    public class ProductDto
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public int StockMin { get; init; }
        public int SupplierId { get; init; }
        public int CategoryId { get; init; }
    }
}
