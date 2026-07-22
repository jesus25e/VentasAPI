using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    internal interface IAuditable
    {
        DateTime CreatedAt { get; }
        DateTime? UpdatedAt { get; }
    }
}
