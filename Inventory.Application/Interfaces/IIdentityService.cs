using Inventory.Application.DTOs.Auth;
using Inventory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<Result<AuthResponse>> RegisterAsync(
                string firstName,
                string lastName,
                string email,
                string password
            );

        Task<Result<LoginResponse>> LoginAsync(string email, string password);
    }
}
