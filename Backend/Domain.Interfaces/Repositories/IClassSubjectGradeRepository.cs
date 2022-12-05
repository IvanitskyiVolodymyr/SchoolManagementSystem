using Common.Dtos.ClassSubjectGrade;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IClassSubjectGradeRepository
    {
        Task<int> InsertClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto);
        Task<int> UpdateClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto);
        Task<IEnumerable<ClassSubjectGrade>> GetGradesByClassSubjectId(int studentId, int classSubjectId);
        Task<IEnumerable<ClassSubjectGrade>> GetAllGradesByClassId(int studentId, int classId);
    }
}
