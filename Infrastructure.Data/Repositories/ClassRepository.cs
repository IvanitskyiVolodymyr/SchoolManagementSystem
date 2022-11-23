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

        public async Task<IEnumerable<int>> InsertClasses(IEnumerable<InsertClassDto> classes)
        {
            List<int> ids = new List<int>();
            foreach(var classDto in classes)
            {
                ids.Add(await _db.SaveData("spClass_Insert", classDto));
            }
            return ids;
        }
    }
}
