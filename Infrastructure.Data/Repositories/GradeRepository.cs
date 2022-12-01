using Common.Dtos.Grades;
using Dapper;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;
using System.Data.SqlClient;

namespace Infrastructure.Data.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public GradeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<SubjectGradesDto>> GetAllGradesWithSubjectsForStudent(int studentId)
        {
            var map = new Dictionary<int, SubjectGradesDto>();
            using var connection = new SqlConnection(_dataAccess.GetConnectionString());
            await connection.OpenAsync();
            var result = await connection.QueryAsync<SubjectGradesDto, Grade, SubjectGradesDto>("spGrade_GetAllWithSubjects",
                map: (subjectGrade, grade) =>
                {
                    if(map.TryGetValue(subjectGrade.ClassSubjectId, out SubjectGradesDto existingSubjectGrades))
                    {
                        subjectGrade = existingSubjectGrades;
                    }
                    else
                    {
                        subjectGrade.Grades = new List<Grade>();
                        map.Add(subjectGrade.ClassSubjectId, subjectGrade);
                    }

                    subjectGrade.Grades.Add(grade);
                    return subjectGrade;
                },
                param: new { StudentId = studentId },
                splitOn: "GradeId",
                commandType: System.Data.CommandType.StoredProcedure);

            return result.Distinct();
        }

        public async Task<IEnumerable<Grade>> GetAllStudentGradesByClassSubjectIdAndPeriod(int studentId, int classSubjectId, DateTime from, DateTime to)
        {
            return await _dataAccess.LoadData<Grade, dynamic>("spGrade_GetByClassSubjectIdAndPeriod", new { StudentId = studentId, ClassSubjectId = classSubjectId, From = from, To = to });
        }

        public async Task<IEnumerable<Grade>> GetAllStudentGradesByStudentIdAndPeriod(int studentId, DateTime from, DateTime to)
        {
            return await _dataAccess.LoadData<Grade, dynamic>("spGrade_GetAllByStudentIdAndPeriod", new { StudentId = studentId, From = from, To = to });
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
