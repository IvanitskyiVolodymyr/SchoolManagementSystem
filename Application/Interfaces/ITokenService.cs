using Application.Auth.Dtos;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJsonWebToken(User user);
        string GenerateRefreshToken();

        int GetUserIdFromToken(string accessToken);
    }
}
