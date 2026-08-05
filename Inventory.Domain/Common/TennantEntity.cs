using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Common
{
    public abstract class TennantEntity: AuditableEntity
    {
        public int TennantId { get; protected set; }
        public void SetTennat(int tennantId)
        {
            TennantId = tennantId;
        }
    }
}
