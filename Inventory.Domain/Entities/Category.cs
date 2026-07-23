using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; private set; }
        private Category() { }
        public Category(string name)
        {
            Name = name;
        }
    }
}
