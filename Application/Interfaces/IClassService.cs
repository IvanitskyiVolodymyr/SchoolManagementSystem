using Common.Dtos.Class;
using Common.Dtos.ClassSubject;

namespace Application.Interfaces
{
    public interface IClassService
    {
        Task<int> CreateClass(InsertClassDto classDto);
        Task<IEnumerable<int>> CreateClasses(IEnumerable<InsertClassDto> classesDto);

        Task<int> AddSubjectToClass(InsertClassSubjectDto classSubjectDto);
        Task<IEnumerable<int>> AddSubjectsToClass(IEnumerable<InsertClassSubjectDto> classSubjects);
    }
}