using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Exceptions
{
    internal class DomainException:Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }
}
