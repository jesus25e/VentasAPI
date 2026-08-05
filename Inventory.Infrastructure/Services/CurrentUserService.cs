using Inventory.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Inventory.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _httpContextAccessor= contextAccessor;
        }

        public string? UserId => _httpContextAccessor.HttpContext?
            .User
            .FindFirstValue(ClaimTypes.NameIdentifier);

        public string? Email => _httpContextAccessor.HttpContext?
            .User
            .FindFirstValue(ClaimTypes.Email);

        public IReadOnlyCollection<string> Roles => _httpContextAccessor.HttpContext?
            .User
            .FindAll(ClaimTypes.Role)
            .Select(x => x.Value)
            .ToList() ?? new List<string>();

        public bool IsAuthenticated => _httpContextAccessor.HttpContext?
            .User?.Identity?.IsAuthenticated ?? false;
    }
}
