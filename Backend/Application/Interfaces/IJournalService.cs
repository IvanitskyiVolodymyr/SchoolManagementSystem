using Common.Dtos.ClassSubjectGrade;
using Common.Dtos.Grades;
using Domain.Core.Entities;

namespace Application.Interfaces
{
    public interface IJournalService
    {
        Task<IEnumerable<SubjectGradesDto>> GetAllGradesWithSubjectsForStudent(int studentId);
        Task<int> InsertClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto);
        Task<int> UpdateClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto);
        Task<IEnumerable<ClassSubjectGrade>> GetAllFinalGradesByClassSubjectId(int studentId, int classSubjectId);
        Task<IEnumerable<ClassSubjectGrade>> GetAllFinalGradesByClassId(int studentId, int classId);
    }
}
