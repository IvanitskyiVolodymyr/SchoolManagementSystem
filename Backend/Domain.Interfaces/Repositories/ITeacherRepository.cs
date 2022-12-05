using Common.Dtos.Users;

namespace Domain.Interfaces.Repositories
{
    public interface ITeacherRepository
    {
        Task<int> CreateTeacher(InsertTeacherDto teacherDto);
    }
}
