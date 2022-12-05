using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUserByEmail(string email);
        Task<UserDto> GetUserById(int id);
        Task<int> UpdateUser(User user);
        Task<ResponseParentDto> CreateParentWithChildrenIds(CreateParentDto parent);
        Task<UserDto> CreateStudent(CreateStudentDto student);
        Task<UserDto> CreateTeacher(CreateTeacherDto teacher);
    }
}