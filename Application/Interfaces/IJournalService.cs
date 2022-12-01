using Common.Dtos.Grades;

namespace Application.Interfaces
{
    public interface IJournalService
    {
        Task<IEnumerable<SubjectGradesDto>> GetAllGradesWithSubjectsForStudent(int studentId);
    }
}
