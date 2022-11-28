using Common.Dtos.StudentTask;
using Common.Dtos.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to);
        Task<int> InsertTaskForStudent(InsertTaskDto taskDto, int studentId);
        Task<int> InsertTaskForStudentsByScheduleId(InsertTaskDto taskDto);
        Task<int> UpdateTask(UpdateTaskDto task);
        Task<int> UpdateStudentTask(UpdateStudentTaskDto studentTask);
    }
}
