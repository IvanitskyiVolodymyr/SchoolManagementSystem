using Application.Interfaces;
using Common.Dtos.Tasks;
using Domain.Core.Entities;
using Domain.Interfaces.Repositories;
using Common.Dtos.StudentTask;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to)
        {
            return await _taskRepository.GetTasksByStudentId(studentId, from, to);
        }

        public async Task<int> InsertTaskForStudentsByScheduleId(InsertTaskDto taskDto)
        {
            return await _taskRepository.InsertTaskForScheduleId(taskDto);
        }

        public async Task<int> InsertTaskForStudent(InsertTaskDto taskDto, int studentId)
        {
            var taskId = await _taskRepository.InsertTask(taskDto);
            return await _taskRepository.InsertStudentTask(new InsertStudentTaskDto { StudentId = studentId, TaskId = taskId });

        }

        public async Task<int> UpdateStudentTask(UpdateStudentTaskDto studentTask)
        {
            return await _taskRepository.UpdateStudentTask(studentTask);
        }

        public async Task<int> UpdateTask(UpdateTaskDto task)
        {
            return await _taskRepository.UpdateTask(task);
        }
    }
}
