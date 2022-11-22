using Common.Dtos.Users;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISqlDataAccess _db;

        public StudentRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> CreateStudent(InsertStudentDto studentDto)
        {
            return await _db.SaveData("spStudent_Insert", studentDto);
        }
    }
}
