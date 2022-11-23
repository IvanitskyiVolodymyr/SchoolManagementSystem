using Common.Dtos.ClassSubject;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;

namespace Infrastructure.Data.Repositories
{
    public class ClassSubjectRepository : IClassSubjectRepository
    {
        private readonly ISqlDataAccess _db;

        public ClassSubjectRepository(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<int> InsertClassSubject(InsertClassSubjectDto classSubjectDto)
        {
            return await _db.SaveData("spClassSubject_Insert", classSubjectDto);
        }

        public async Task<IEnumerable<int>> InsertClassSubjects(IEnumerable<InsertClassSubjectDto> classSubjects)
        {
            List<int> ids = new List<int>();

            foreach(var classSubject in classSubjects)
            {
                ids.Add(await _db.SaveData("spClassSubject_Insert", classSubject));
            }

            return ids;
        }
    }
}
