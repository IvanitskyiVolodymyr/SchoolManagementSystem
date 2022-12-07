using Common.Dtos.Users;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ISqlDataAccess _db;

        public UserRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            return _db.LoadData<User, dynamic>(
                "dbo.spUser_GetAll",
                new { });
        }

        public async Task<User?> GetUserById(int userId)
        {
            var results = await _db.LoadData<User, dynamic>(
                "dbo.spUser_GetById",
                new { UserId = userId });

            return results.FirstOrDefault();
        }

        public async Task<int> InsertUser(InsertUserDto user)
        {
            return await _db.SaveData("dbo.spUser_Insert", user);
        }

        public async Task<int> UpdateUser(User user)
        {
            return await _db.SaveData("dbo.spUser_Update", user);
        }

        public async Task DeleteUser(int id) =>
            await _db.SaveData("dbo.spUser_Delete", new { UserId = id });

        public async Task<User?> GetUserByEmail(string email)
        {
            var results = await _db.LoadData<User, dynamic>(
                "dbo.spUser_GetByEmail",
                new { Email = email });

            return results.FirstOrDefault();
        }

        public async Task<Student?> GetStudentByUserId(int userId)
        {
            var result = await _db.LoadData<Student, dynamic>("spStudent_GetByUserId", new { UserId = userId });
            return result.FirstOrDefault();
        }

        public async Task<Teacher?> GetTeacherByUserId(int userId)
        {
            var result = await _db.LoadData<Teacher, dynamic>("spTeacher_GetByUserId", new { UserId = userId });
            return result.FirstOrDefault();
        }

        public async Task<Parent?> GetParentByUserId(int userId)
        {
            var result = await _db.LoadData<Parent, dynamic>("spParent_GetByUserId", new { UserId = userId });
            return result.FirstOrDefault();
        }
    }
}
