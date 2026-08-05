using Inventory.Application.DTOs.Auth;
using Inventory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    public interface ISessionService
    {
        Task<Result<LoginResponse>> RefreshTokenAsync(string refreshToken);
        Task<Results> LogoutAsync(string refreshToken);
    }
}