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

        public async Task<int> CreateParentStudent(int parentId, int studentId)
        {
            return await _db.SaveData("spParentStudent_Insert", new { ParentId = parentId, StudentId = studentId});
        }
    }
}
