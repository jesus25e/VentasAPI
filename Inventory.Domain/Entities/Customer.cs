using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Customer:BaseEntity
    {
        public string FullName { get; private set; }
        public string Email { get; private set; }
        private Customer() { }
        public Customer(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }
    }
}
