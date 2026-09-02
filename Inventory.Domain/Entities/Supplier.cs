using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Supplier:TenantEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? CompanyName { get; private set; }
        public string Phone { get; private set; }
        public string? Address { get; private set; }
        private Supplier() { }
        public Supplier(string name, string? companyName, string phone, string? address)
        {
            Name = name;
            CompanyName = companyName;
            Phone = phone;
            Address = address;
        }

        public void Update(string name, string? companyName, string phone, string? address)
        {
            Name = name;
            CompanyName = companyName;
            Phone=phone;
            Address = address;
        }
    }
}
