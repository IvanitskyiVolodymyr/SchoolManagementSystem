using Common.Dtos.Users;

namespace Domain.Interfaces.Repositories
{
    public interface IStudentRepository
    {
        Task<int> CreateStudent(InsertStudentDto studentDto);
    }
}
