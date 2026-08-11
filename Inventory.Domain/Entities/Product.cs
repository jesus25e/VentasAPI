using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Product : TenantEntity
    {
        public string Name { get; private set; }
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public int CategoryId { get; private set; }

        public int SupplierId { get; private set; }

        private Product(string name)
        {
            Name = name;
        }

        public Product(
            string name,
            string description,
            decimal price,
            int stock,
            int categoryId,
            int supplierId
            )
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
            SupplierId = supplierId;
        }

        public void Update(
            string name,
            string description,
            decimal price,
            int stock,
            int categoryId,
            int supplierId
        )
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            CategoryId = categoryId;
        }


    }
}
