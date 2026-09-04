
using Inventory.Domain.Common;

namespace Inventory.Domain.Entities
{
    public class Sale:TenantEntity
    {
        public DateTime SaleDate { get; private set; }
        public int? CustomerId { get; private set; }
        public decimal Total { get; private set; }
        private Sale() { }
        public Sale(decimal total, DateTime saleDate, int? customerId)
        {
            SaleDate = saleDate;
            CustomerId = customerId;
            Total = total;
        }
    }
}
