using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<int> InsertRefreshToken(RefreshToken token);
        Task<RefreshToken?> GetRefreshToken(string token);
        Task DeleteRefreshToken(int refreshTokenId);
    }
}
 