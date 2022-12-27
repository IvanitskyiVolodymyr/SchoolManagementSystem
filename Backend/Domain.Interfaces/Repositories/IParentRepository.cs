using Common.Dtos.ParentStudent;
using Common.Dtos.Users;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IParentRepository
    {
        Task<int> CreateParent(InsertParentDto parentDto);
        Task<int> CreateParentStudent(int parentId, int studentId);
        Task<IEnumerable<ParentStudentDto>> GetParentsStudents(int parentId);
    }
}
