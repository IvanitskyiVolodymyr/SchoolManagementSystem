using Common.Dtos.Grades;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IGradeRepository
    {
        public Task<Grade?> GetByStudentTaskId(int studentTaskId);
        public Task<IEnumerable<Grade>> GetAllStudentGradesByStudentIdAndPeriod(int studentId, DateTime from, DateTime to);
        public Task<IEnumerable<Grade>> GetAllStudentGradesByClassSubjectIdAndPeriod(int studentId, int classSubjectId, DateTime from, DateTime to);
        public Task<IEnumerable<SubjectGradesDto>> GetAllGradesWithSubjectsForStudent(int studentId);
        public Task<int> InsertGrade(InsertGradeDto gradeDto);
        public Task<int> UpdateGrade(InsertGradeDto gradeDto);
    }
}
