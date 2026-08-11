using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Common
{
    public abstract class TenantEntity: AuditableEntity
    {
        public string TenantId { get; protected set; } = string.Empty;
        public void SetTenant(string tenantId)
        {
            if (string.IsNullOrWhiteSpace(TenantId))
            {
                TenantId = tenantId;
            }
        }
    }
}
