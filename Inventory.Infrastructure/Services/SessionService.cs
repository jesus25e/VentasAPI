using Inventory.Application.DTOs.Auth;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Configurations;
using Inventory.Infrastructure.Identity;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Security;
using Inventory.Shared.Result;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Services
{
    public class SessionService : ISessionService
    {
        public readonly IRefreshTokenService _refreshTokenService;
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager;
        public readonly IJwtTokenService _jwtTokenService;
        public readonly JwtOptions _jwtOptions;

        public SessionService(
            IRefreshTokenService sessionService, 
            ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager, 
            IJwtTokenService jwtTokenService,
            IOptions<JwtOptions> jwtOptions)
        {
            _refreshTokenService = sessionService;
            _context = context;
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<Result<LoginResponse>> RefreshTokenAsync(string refreshToken)
        {
            var hash = _refreshTokenService.ComputeHash(refreshToken);

            var storedToken = await _context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Token == hash);

            Console.WriteLine($"Session Service: '{storedToken?.Token}'");

            if (storedToken is null)
            {
                return Result<LoginResponse>.Failure("Refresh Token inválido.");
            }

            if (storedToken.IsExpired)
            {
                return Result<LoginResponse>.Failure("El Token ha expirado.");
            }

            if (storedToken.IsRevocked) return Result<LoginResponse>.Failure("El Token ya fue revocado");

            var user = storedToken.User;

            if (user is null)
            {
                return Result<LoginResponse>.Failure("Usuario no encontrado.");
            }

            var newRefreshToken = await _refreshTokenService.GenerateRefreshTokenAsync();

            var refreshExpiration = _refreshTokenService.GetExpirationDate();

            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = _refreshTokenService.ComputeHash(newRefreshToken),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = refreshExpiration,
                UserId = user.Id
            };

            storedToken.RevockedAt = DateTime.UtcNow;
            _context.RefreshTokens.Update(storedToken);

            user.RefreshTokens.Add(refreshTokenEntity);

            var authUser = new AuthUser
            {
                Id = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                TenantId = user.TenantId,
                Roles = await _userManager.GetRolesAsync(user)
            };

            var accessToken = await _jwtTokenService.GenerateAccessTokenAsync(authUser);

            storedToken.RevockedAt = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);
            await _context.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return Result<LoginResponse>.Success(new LoginResponse(
                    user.Id,
                    user.Email!,
                    accessToken,
                    newRefreshToken,
                    DateTime.UtcNow.AddMinutes(_jwtOptions.ExpirationMinutes),
                    refreshExpiration
                ));
        }
        public async Task<Results> LogoutAsync(string refreshToken)
        {
            var hash =  _refreshTokenService.ComputeHash(refreshToken);
            var storedToken =  _context.RefreshTokens
                .Include(x => x.User)
                .FirstOrDefault(x => x.Token == hash);

            if (storedToken is null)
            {
                return Results.Failure("Refresh Token inválido.");
            }

            if (storedToken.IsRevocked)
            {
                return Results.Failure("Token ya Eliminado");
            }

            storedToken.RevockedAt = DateTime.UtcNow;

            _context.RefreshTokens.Update(storedToken);
            await _context.SaveChangesAsync();

            return Results.Success();
        }
    }
}
