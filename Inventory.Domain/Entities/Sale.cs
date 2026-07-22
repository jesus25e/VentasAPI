using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    internal class Sale:BaseEntity
    {
        public decimal Total { get; private set; }
        public DateTime SaleDate { get; private set; }
        public int CustomerId { get; private set; }
        private Sale() { }
        public Sale(decimal total, DateTime saleDate, int customerId)
        {
            Total = total;
            SaleDate = saleDate;
            CustomerId = customerId;
        }
    }
}
