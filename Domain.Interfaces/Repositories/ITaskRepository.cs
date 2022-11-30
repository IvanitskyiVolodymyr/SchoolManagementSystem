using Common.Dtos.StudentTask;
using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.Tasks;
using Domain.Core.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to);//get unchecked
        Task<IEnumerable<ResponseTeacherTaskDto>> GetUncheckedTasksByTeacherIdSubjectIdClassId(int teacherId, int subjectId, int classId);
        Task<IEnumerable<StudentTaskAttachmentDto>> GetStudentTaskAttachments(int studentTaskId);
        Task<StudentTask?> GetStudentTaskById(int studentTaskId);
        Task<IEnumerable<ResponseTaskDto>> GetCheckedStudentTaskByStudentId(int studentId, DateTime from, DateTime to);
        Task<int> InsertTask(InsertTaskDto taskDto);
        Task<int> InsertTaskForScheduleId(InsertTaskDto taskDto);
        Task<int> InsertStudentTask(InsertStudentTaskDto studentTaskDto);
        Task<int> UpdateStudentTask(UpdateStudentTaskDto studentTaskDto);
        Task<int> UpdateStudentTaskWithAttachments(UpdateStudentTaskDto studentTaskDto, List<InsertStudentTaskAttachmentDto> attachments);
        Task<int> UpdateTask(UpdateTaskDto task);
    }
}
