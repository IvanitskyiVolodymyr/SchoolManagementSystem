using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateJsonWebToken(User user);
        string GenerateRefreshToken();

        int GetUserIdFromToken(string accessToken);
    }
}
