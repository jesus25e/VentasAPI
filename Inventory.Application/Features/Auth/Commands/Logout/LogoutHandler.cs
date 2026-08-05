using Inventory.Application.DTOs.Auth;
using Inventory.Application.Interfaces;
using Inventory.Shared.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventory.Application.Features.Auth.Commands.Logout
{
    public class LogoutHandler : IRequestHandler<LogoutCommand, Results>
    {
        public readonly ISessionService _sessionService;

        public LogoutHandler(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<Results> Handle(LogoutCommand command, CancellationToken cancellationToken)
        {
            return await _sessionService.LogoutAsync(command.RefreshToken);
        }
    }
}
