using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<int> CreateUser(InsertUserDto user);
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> GetUserById(int id);
        Task<int> UpdateUser(User user);
    }
}