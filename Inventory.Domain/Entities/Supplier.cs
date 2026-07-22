using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    internal class Supplier:BaseEntity
    {
        public string Name { get; private set; }
        public string Prhone { get; private set; }
        private Supplier() { }
        public Supplier(string name, string phone)
        {
            Name = name;
            Prhone = phone;
        }
    }
}
