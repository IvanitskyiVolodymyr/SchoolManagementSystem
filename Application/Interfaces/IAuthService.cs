using Application.Auth.Dtos;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDto> Register(RegisterDto user);
        public Task<AuthUserDto> Login(LoginDto user);
    }
}
