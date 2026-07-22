using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Domain.Entities
{
    internal class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; protected set; }
        public bool isDeleted { get; protected set; } = false;
        public void MarkAsUpdated()
        {
            UpdatedAt = DateTime.Now;
        }

        public void Deleted()
        {
            isDeleted = true;
            UpdatedAt = DateTime.Now;
        }
    }
}
