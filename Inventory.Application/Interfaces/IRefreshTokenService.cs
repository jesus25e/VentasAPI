using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    public interface IRefreshTokenService
    {
        Task<string> GenerateRefreshTokenAsync();
        DateTime GetExpirationDate();
        string ComputeHash(string token);
    }
}
