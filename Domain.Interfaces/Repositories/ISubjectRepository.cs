using Common.Dtos.Subject;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ISubjectRepository
    {
        Task<int> InsertSubject(InsertSubjectDto subjectDto);
        Task<IEnumerable<int>> InsertSubjects(IEnumerable<InsertSubjectDto> subjects);
        Task<IEnumerable<Subject>> GetAllSubjects();
        Task<IEnumerable<StudentSubjectResponseDto>> GetSubjectsByStudentId(int studentId);
    }
}
