using Common.Dtos.Subject;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ISqlDataAccess _db;

        public SubjectRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjects()
        {
            return await _db.LoadData<Subject, dynamic>("spSubject_GetAll", new { });
        }

        public async Task<IEnumerable<StudentSubjectResponseDto>> GetSubjectsByStudentId(int studentId)
        {
            return await _db.LoadData<StudentSubjectResponseDto, dynamic>("spSubject_GetAllByStudentId", new { StudentId = studentId });
        }

        public async Task<int> InsertSubject(InsertSubjectDto subjectDto)
        {
            return await _db.SaveData("spSubject_Insert", subjectDto);
        }

        public async Task<IEnumerable<int>> InsertSubjects(IEnumerable<InsertSubjectDto> subjects)
        {
            List<int> ids = new List<int>();

            foreach(var subject in subjects)
            {
                ids.Add(await _db.SaveData("spSubject_Insert", subject));
            }

            return ids;
        }
    }
}
