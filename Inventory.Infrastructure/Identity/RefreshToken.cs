using Inventory.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Identity
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? RevockedAt { get; set; }
        public bool IsRevocked => RevockedAt.HasValue;
        public bool IsExpired => DateTime.UtcNow >= ExpiresAt;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = default;
    }
}
