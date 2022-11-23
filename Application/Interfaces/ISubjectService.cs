using Common.Dtos.Subject;
using Common.Dtos.SubjectTeacher;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface ISubjectService
    {
        Task<int> CreateSubject(InsertSubjectDto subjectDto);
        Task<IEnumerable<int>> CreateSubjects(IEnumerable<InsertSubjectDto> subjects);
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<int> AddTeacherToSubject(InsertSubjectTeacherDto subjectTeacherDto);
    }
}
