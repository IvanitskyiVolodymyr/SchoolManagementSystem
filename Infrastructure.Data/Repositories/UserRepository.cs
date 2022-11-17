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

        public async Task<int> InsertUser(User user)
        {
            return await _db.SaveData("dbo.spUser_Insert",
                new
                {
                    user.FirstName,
                    user.RoleId,
                    user.MiddleName,
                    user.LastName,
                    user.Gender,
                    user.PhoneNumber,
                    user.Email,
                    user.Address,
                    user.PasswordSalt,
                    user.PasswordHash,
                    user.BirthDate,
                    user.JoinDate,
                    user.AvatarUrl
                });
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
    }
}
