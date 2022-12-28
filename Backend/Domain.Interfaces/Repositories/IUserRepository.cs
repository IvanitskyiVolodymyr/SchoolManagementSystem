using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task DeleteUser(int id);
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByEmail(string email);
        Task<int> GetClassIdByStudentId(int studentId);
        Task<IEnumerable<User>> GetUsers();
        Task<int> InsertUser(InsertUserDto user);
        Task<int> UpdateUser(User user);
        Task<Student?> GetStudentByUserId(int userId);
        Task<Teacher?> GetTeacherByUserId(int userId);
        Task<Parent?> GetParentByUserId(int userId);
        Task<Role?> GetRoleByUserId(int userId);
    }
}
