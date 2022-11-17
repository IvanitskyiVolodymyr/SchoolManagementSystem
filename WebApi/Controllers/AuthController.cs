using Application.Auth.Dtos;
using Application.Interfaces;
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

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto user)
        {
            return Ok(await _authService.Register(user));
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto user)
        {
            return Ok(await _authService.Login(user));
        }
    }
}
