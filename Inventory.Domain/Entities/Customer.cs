using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Customer:TenantEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        private Customer() { }
        public Customer(string fullName, string email, string phone)
        {
            FullName = fullName;
            Email = email;
            Phone = phone;
        }
    }
}
