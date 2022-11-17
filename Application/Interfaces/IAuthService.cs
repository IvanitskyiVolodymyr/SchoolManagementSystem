using Application.Auth.Dtos;
using Domain.Core.Common.Auth;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface IAuthService
    {
        public Task<UserDto> Register(RegisterDto user);
        public Task<UserDto> Login(LoginDto user);
    }
}
