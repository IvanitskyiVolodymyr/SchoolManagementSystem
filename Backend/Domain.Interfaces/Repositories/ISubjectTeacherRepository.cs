using Common.Dtos.SubjectTeacher;

namespace Domain.Interfaces.Repositories
{
    public interface ISubjectTeacherRepository
    {
        Task<int> AddTeacherToSubject(InsertSubjectTeacherDto teacherSubjectDto);
    }
}
