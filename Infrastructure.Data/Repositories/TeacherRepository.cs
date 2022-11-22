using Common.Dtos.Users;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly ISqlDataAccess _db;

        public TeacherRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> CreateTeacher(InsertTeacherDto teacherDto)
        {
            return await _db.SaveData("spTeacher_Insert", teacherDto);
        }
    }
}
