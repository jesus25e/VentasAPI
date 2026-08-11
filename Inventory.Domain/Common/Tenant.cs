using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Common
{
    public class Tenant: AuditableEntity
    {
        public string Id { get;  set; } = Guid.NewGuid().ToString();
        public string Name { get;  set; } = string.Empty;
        public string Code { get;  set; } = string.Empty;
        public bool IsActive { get;  set; } = true;
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
