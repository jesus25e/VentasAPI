using Inventory.Infrastructure.Configurations;
using Inventory.Infrastructure.Identity;
using Inventory.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory.Infrastructure.Services
{
    public class JwtTokenService:IJwtTokenService
    {
        private readonly JwtOptions _options;
        public JwtTokenService(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public Task<string>GenerateAccessTokenAsync(AuthUser user)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email),
                new("TenantId", user.TenantId),
                new(ClaimTypes.Name,user.FirstName),
                new(ClaimTypes.Surname,user.LastName)
            };

            foreach (var role in user.Roles)
            {
                claims.Add(
                    new Claim(
                        ClaimTypes.Role, role)
                    );
            }
            //Console.WriteLine($"JWT Key: '{_options.Key}'");
            //Console.WriteLine($"Length: {_options.Key.Length}");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
                (
                    issuer:_options.Issuer,
                    audience:_options.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(_options.ExpirationMinutes),
                    signingCredentials:credentials
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Task.FromResult( tokenString );
        }
    }
}
