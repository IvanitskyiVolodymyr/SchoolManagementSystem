using Common.Dtos.Auth;
using Common.Dtos.Users;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDto> Register(RegisterDto user);
        public Task<AuthUserDto> Login(LoginDto user);
        public Task<AuthUserDto> RefreshToken(TokenModel token);
        public Task RevokeRefreshToken(string refreshToken);
    }
}
