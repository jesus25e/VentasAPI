using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Auth
{
    public record RefreshTokenRequest
    (
        string RefreshToken    
    );
}
