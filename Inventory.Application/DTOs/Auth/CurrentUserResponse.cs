using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.DTOs.Auth
{
    public record CurrentUserResponse
    (
        string Id,
        string Name,
        string Email,
        IList<string> Roles
    );
}
