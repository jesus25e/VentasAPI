using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class SaleDetails : TenantEntity
    {
        public int SaleId { get; private set; }
        public int ProductId { get; private set; }
        public int Quantity { get; private set; } = 0;
        public decimal PriceAtSale { get; private set; } 
        public decimal SubTotal { get; private set; } 

        public SaleDetails(
            int saleId,
            int productId,
            int quantity,
            decimal priceAtSale,
            decimal subTotal
            )
        {
            SaleId = saleId;
            ProductId = productId;
            Quantity = quantity;
            PriceAtSale = priceAtSale;
            SubTotal = subTotal;
        }
    }
}
