using Common.Dtos.Users;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly ISqlDataAccess _db;

        public ParentRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> CreateParent(InsertParentDto parentDto)
        {
            return await _db.SaveData("spParent_Insert", parentDto);
        }
    }
}
