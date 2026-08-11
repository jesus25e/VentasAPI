using Inventory.Application.Common.Authorization;
using Inventory.Application.Features.Auth.Commands.Login;
using Inventory.Application.Features.Auth.Commands.Logout;
using Inventory.Application.Features.Auth.Commands.RefreshToken;
using Inventory.Application.Features.Auth.Commands.Register;
using Inventory.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess) return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(LogoutCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [Authorize(Policy = Policies.AdminOnly)]
        [HttpGet("me")]
        public IActionResult Me([FromServices] ICurrentUserService currentUser)
        {
            return Ok(new
            {
                currentUser.TenantId,
                currentUser.Email,
                currentUser.Roles,
                currentUser.IsAuthenticated
            });
        }

        [Authorize(Policy = Policies.AdminOnly)]
        [HttpGet("only-admin")]
        public IActionResult OnlyAdmin()
        {
            return Ok("Bienvenido Administrador");
        }
    }
}
