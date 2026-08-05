using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Auth
{
    public record AuthResponse
    (
        string UserId,
        string Email,
        string Message
    );
}
