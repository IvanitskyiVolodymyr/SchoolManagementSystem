using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task DeleteUser(int id);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<IEnumerable<User>> GetUsers();
        Task<int> InsertUser(InsertUserDto user);
        Task<int> UpdateUser(User user);
    }
}
