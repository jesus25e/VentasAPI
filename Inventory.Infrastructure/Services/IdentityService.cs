using Inventory.Application.DTOs.Auth;
using Inventory.Application.Interfaces;
using Inventory.Domain.Entities;
using Inventory.Infrastructure.Configurations;
using Inventory.Infrastructure.Identity;
using Inventory.Infrastructure.Persistence;
using Inventory.Infrastructure.Security;
using Inventory.Shared.Result;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IRefreshTokenService _refreshTokenService;
        private readonly JwtOptions _jwtOption;
        private readonly ApplicationDbContext _context;
        public IdentityService
        (
            UserManager<ApplicationUser> userManager,
            IJwtTokenService jwtTokenService,
            IRefreshTokenService refreshTokenService,
            IOptions<JwtOptions> jwtOptions,
            ApplicationDbContext context
        )
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _refreshTokenService = refreshTokenService;
            _jwtOption = jwtOptions.Value;
            _context = context;
        }

        public async Task<Result<LoginResponse>> LoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                return Result<LoginResponse>
                    .Failure("Credenciales incorrectas.");
            }

            var validPassword = await _userManager.CheckPasswordAsync(user, password);

            if (!validPassword)
            {
                return Result<LoginResponse>
                    .Failure("Credenciales incorrectas.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var authUser = new AuthUser
            {
                Id = user.Id,
                Email = user.Email!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                TenantId = user.TenantId,
                Roles = roles.ToList(),
            };

            var token = await _jwtTokenService.GenerateAccessTokenAsync(authUser);
            var refreshToken = await _refreshTokenService.GenerateRefreshTokenAsync();
            var refreshExpiration = _refreshTokenService.GetExpirationDate();

            var refreshTokenEntity = new RefreshToken
            {
                Id = Guid.NewGuid(),
                Token = _refreshTokenService.ComputeHash(refreshToken),
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = _refreshTokenService.GetExpirationDate(),
                UserId = user.Id,
               
            };

            await _context.RefreshTokens.AddAsync(refreshTokenEntity);
            await _context.SaveChangesAsync();

            return Result<LoginResponse>
                .Success(new LoginResponse(
                    user.Id,
                    user.Email!,
                    token,
                    refreshToken,
                    DateTime.UtcNow.AddMinutes(_jwtOption.ExpirationMinutes),
                    refreshExpiration
                    ));
        }

        public async Task<Result<AuthResponse>> RegisterAsync(string firstName, string lastName, string email, string password)
        {
            var exists = await _userManager.FindByEmailAsync(email);

            if (exists != null)
            {
                return Result<AuthResponse>.Failure("El correo ya está registrado");
            }

            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded)
            {
                return Result<AuthResponse>.Failure
                    (
                        string.Join(",", result.Errors.Select(e => e.Description))
                    );
            }

            await _userManager.AddToRoleAsync(user, Roles.Seller);

            return Result<AuthResponse>.Success(
                new AuthResponse(user.Id, user.Email!, "Usuario Registrado Correctamente"));
        }
    }
}
