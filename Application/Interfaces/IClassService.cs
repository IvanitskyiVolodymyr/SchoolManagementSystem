using Common.Dtos.Class;

namespace Application.Interfaces
{
    public interface IClassService
    {
        Task<int> CreateClass(InsertClassDto classDto);
        Task<List<int>> CreateClasses(List<InsertClassDto> classesDto);
    }
}