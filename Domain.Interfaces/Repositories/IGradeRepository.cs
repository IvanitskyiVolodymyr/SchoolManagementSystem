using Common.Dtos.Grades;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IGradeRepository
    {
        public Task<Grade?> GetByStudentTaskId(int studentTaskId);
        public Task<int> InsertGrade(InsertGradeDto gradeDto);
        public Task<int> UpdateGrade(InsertGradeDto gradeDto);
    }
}
