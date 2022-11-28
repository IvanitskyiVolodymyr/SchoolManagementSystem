using Common.Dtos.StudentTask;
using Common.Dtos.Tasks;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to);
        Task<int> InsertTask(InsertTaskDto taskDto);
        Task<int> InsertTaskForScheduleId(InsertTaskDto taskDto);
        Task<int> InsertStudentTask(InsertStudentTaskDto studentTaskDto);
        Task<int> UpdateStudentTask(UpdateStudentTaskDto studentTaskDto);
        Task<int> UpdateTask(UpdateTaskDto task);
    }
}
