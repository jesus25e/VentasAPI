using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Common
{
    public class Tenant: AuditableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
        public Tenant() { }
        public Tenant(string name, string code)
        {
            Name = name;
            Code = code;
        }
        public void Disable()
        {
            IsActive = false;
        }
    }
}
