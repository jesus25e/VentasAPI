using Inventory.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Customer:TenantEntity
    {
        public string? FullName { get; private set; }
        public int DNI { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public string? Address { get; private set; }
        private Customer() { }
        public Customer(string? fullName, int dni, string? email, string? phone, string? address)
        {
            FullName = fullName;
            DNI = dni;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public void Update(
            string fullName,
            int dni,
            string email,
            string phone,
            string address
            )
        {
            FullName = fullName;
            DNI = dni;
            Email = email;
            Phone = phone;
            Address= address;
        }
    }
}
