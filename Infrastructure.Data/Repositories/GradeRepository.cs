using Common.Dtos.Grades;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public GradeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Grade?> GetByStudentTaskId(int studentTaskId)
        {
            var results = await _dataAccess.LoadData<Grade, dynamic>(
                "spGrade_GetByStudentTaskId",
                new { StudentTaskId = studentTaskId });

            return results.FirstOrDefault();
        }

        public async Task<int> InsertGrade(InsertGradeDto gradeDto)
        {
            return await _dataAccess.SaveData("spGrade_Insert", gradeDto);
        }

        public async Task<int> UpdateGrade(InsertGradeDto gradeDto)
        {
            await _dataAccess.SaveData("spGrade_Update", gradeDto);
            return gradeDto.Value;
        }
    }
}
