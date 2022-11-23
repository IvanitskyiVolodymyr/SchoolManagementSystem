using Common.Dtos.Class;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly ISqlDataAccess _db;

        public ClassRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> InsertClass(InsertClassDto classDto)
        {
            return await _db.SaveData("spClass_Insert", classDto);
        }
    }
}
