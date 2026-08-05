using Inventory.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Inventory.Infrastructure.Services
{
    public class RefreshTokenService : IRefreshTokenService
    {

        public Task<string> GenerateRefreshTokenAsync()
        {
            var bytes = RandomNumberGenerator.GetBytes(64);

            return Task.FromResult(Convert.ToBase64String(bytes));
        }

        public DateTime GetExpirationDate()
        {
            return DateTime.UtcNow.AddDays(7);
        }
        public string ComputeHash(
            string token)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(token));

            return Convert.ToHexString(bytes);
        }

    }
}
