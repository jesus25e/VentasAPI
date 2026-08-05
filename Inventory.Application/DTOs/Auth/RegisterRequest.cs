using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Auth
{
    public record RegisterRequest
    (
        string FirstName,
        string LastName,
        string Email,
        string password
    );
}
