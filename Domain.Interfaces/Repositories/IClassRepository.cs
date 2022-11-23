using Common.Dtos.Class;

namespace Domain.Interfaces.Repositories
{
    public interface IClassRepository
    {
        Task<int> InsertClass(InsertClassDto classDto);
    }
}
