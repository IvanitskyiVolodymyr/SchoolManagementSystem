using Common.Dtos.SubjectTeacher;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class SubjectTeacherRepository : ISubjectTeacherRepository
    {
        private readonly ISqlDataAccess _db;

        public SubjectTeacherRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> AddTeacherToSubject(InsertSubjectTeacherDto subjectTeacherDto)
        {
            return await _db.SaveData("spSubjectTeacher_Insert", subjectTeacherDto);
        }
    }
}
