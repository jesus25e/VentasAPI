using Inventory.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Security
{
    public interface IJwtTokenService
    {
        Task<string> GenerateAccessTokenAsync(AuthUser user);
    }
}
