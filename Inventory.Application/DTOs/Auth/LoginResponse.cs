using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Auth
{
    public record LoginResponse
    (
        string UserId,
        string Email,
        string AccessToken,
        string RefreshToken,
        DateTime ExpiresAt,
        DateTime RefreshTokenExpiresAt
    );
}
