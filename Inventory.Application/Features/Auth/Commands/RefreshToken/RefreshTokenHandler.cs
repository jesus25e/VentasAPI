using Inventory.Application.DTOs.Auth;
using Inventory.Application.Interfaces;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenHandler:IRequestHandler<RefreshTokenCommand,Result<LoginResponse>>
    {
        private readonly ISessionService _sessionService;

        public RefreshTokenHandler(ISessionService sessionService)
        {
            _sessionService= sessionService;
        }

        public async Task<Result<LoginResponse>> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
        {
            return await _sessionService.RefreshTokenAsync(command.RefreshToken);
        }
    }
}
