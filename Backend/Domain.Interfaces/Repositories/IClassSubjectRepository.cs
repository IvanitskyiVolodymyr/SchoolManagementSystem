using Common.Dtos.ClassSubject;

namespace Domain.Interfaces.Repositories
{
    public interface IClassSubjectRepository
    {
        Task<int> InsertClassSubject(InsertClassSubjectDto classSubjectDto);
        Task<IEnumerable<int>> InsertClassSubjects(IEnumerable<InsertClassSubjectDto> classSubjects);
    }
}
