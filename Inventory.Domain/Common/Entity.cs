using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Common
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
