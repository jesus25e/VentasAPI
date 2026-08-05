using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Auth
{
    public record LoginRequest
    (
        string Email,
        string password
    );
}
