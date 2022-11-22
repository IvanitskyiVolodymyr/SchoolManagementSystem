using Common.Dtos.Users;

namespace Domain.Interfaces.Repositories
{
    public interface IParentRepository
    {
        Task<int> CreateParent(InsertParentDto parentDto);
    }
}
