using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJsonWebToken(User user);
        Task<string> GenerateRefreshToken(string accessToken);
    }
}
