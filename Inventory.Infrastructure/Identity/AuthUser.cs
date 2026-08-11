using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Identity
{
    public class AuthUser
    {
        public string Id { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public string TennantId { get; init; } = string.Empty;
        public IList<string> Roles { get; init; } = new List<string>();
        public string? TenantId { get; internal set; }
    }
}
