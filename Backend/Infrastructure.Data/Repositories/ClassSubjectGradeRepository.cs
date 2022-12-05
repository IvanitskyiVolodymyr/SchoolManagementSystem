using Common.Dtos.ClassSubjectGrade;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class ClassSubjectGradeRepository : IClassSubjectGradeRepository
    {
        private readonly ISqlDataAccess _dataAccess;

        public ClassSubjectGradeRepository(ISqlDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<ClassSubjectGrade>> GetAllGradesByClassId(int studentId, int classId)
        {
            return await _dataAccess.LoadData<ClassSubjectGrade, dynamic>("spClassSubjectGrade_GetByClassId", new { StudentId = studentId, ClassId = classId });
        }

        public async Task<IEnumerable<ClassSubjectGrade>> GetGradesByClassSubjectId(int studentId, int classSubjectId)
        {
            return await _dataAccess.LoadData<ClassSubjectGrade, dynamic>("spClassSubjectGrade_GetByClassSubjectId", new { StudentId = studentId, ClassSubjectId = classSubjectId});
        }

        public async Task<int> InsertClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto)
        {
            return await _dataAccess.SaveData("spClassSubjectGrade_Insert", subjectGradeDto);
        }

        public async Task<int> UpdateClassSubjectGrade(InsertClassSubjectGradeDto subjectGradeDto)
        {
            return await _dataAccess.SaveData("spClassSubjectGrade_Update", subjectGradeDto);
        }
    }
}
