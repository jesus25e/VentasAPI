using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string TenantId { get; }
        string? Email { get; }
        IReadOnlyCollection<string> Roles { get; }
        bool IsAuthenticated { get; }
    }
}
