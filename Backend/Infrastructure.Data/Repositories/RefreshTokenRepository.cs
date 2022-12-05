using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ISqlDataAccess _db;

        public RefreshTokenRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task DeleteRefreshToken(int refreshTokenId)
        {
            await _db.SaveData("spRefreshToken_Delete", new { RefreshTokenId = refreshTokenId });
        }

        public async Task<RefreshToken?> GetRefreshToken(string token)
        {
            var result = await _db.LoadData<RefreshToken, dynamic>(
                "spRefreshToken_Get",
                new { Token = token });

            return result.FirstOrDefault();
        }

        public async Task<int> InsertRefreshToken(RefreshToken token)
        {
            return await _db.SaveData(
                "spRefreshToken_Insert",
                token);
        }
    }
}
