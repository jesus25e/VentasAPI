using Inventory.Application.DTOs.Auth;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Auth.Commands.Login
{
    public record LoginCommand
    (
        string Email,
        string Password
    ):IRequest<Result<LoginResponse>>;

    
}
