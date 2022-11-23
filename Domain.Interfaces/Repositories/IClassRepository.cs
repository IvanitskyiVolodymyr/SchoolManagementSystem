using Common.Dtos.Class;

namespace Domain.Interfaces.Repositories
{
    public interface IClassRepository
    {
        Task<int> InsertClass(InsertClassDto classDto);
        Task<List<int>> InsertClasses(List<InsertClassDto> classesDto);
    }
}
