using Application.Interfaces;
using Common.Dtos.Auth;
using Common.Dtos.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthUserDto>> Login([FromBody] LoginDto user)
        {
            return Ok(await _authService.Login(user));
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<AuthUserDto>> Refresh([FromBody] TokenModel token)
        {
            return Ok(await _authService.RefreshToken(token));
        }

        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshToken([FromBody] string refreshToken)
        {
            await _authService.RevokeRefreshToken(refreshToken);
            return Ok();
        }
    }
}
