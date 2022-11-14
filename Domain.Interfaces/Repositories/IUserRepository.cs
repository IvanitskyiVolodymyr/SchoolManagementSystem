using Domain.Core.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task DeleteUser(int id);
        Task<User?> GetUserById(int id);
        Task<IEnumerable<User>> GetUsers();
        Task InsertUser(User user);
        Task UpdateUser(User user);
    }
}
