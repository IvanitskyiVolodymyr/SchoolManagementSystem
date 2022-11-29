using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        //ForStudent
        Task<IEnumerable<ResponseTaskDto>> GetTasksByStudentId(int studentId, DateTime from, DateTime to);

        //ForTeacher
        //Task<IEnumerable<ResponseTaskDto>> GetTasksByTeacherIdAndSubjectId(string studentName);

        //ForTeacher
        Task<int> InsertTaskForStudent(InsertTaskDto taskDto, int studentId);

        //ForTeacher
        Task<int> InsertTaskForStudentsByScheduleId(InsertTaskDto taskDto);

        //ForTeacher
        Task<int> UpdateTask(UpdateTaskDto task);

        //ForStudent
        Task<int> SubmitStudentTask(int studentTaskId, List<StudentTaskAttachmentDto> attachments);

        //ForTeacher
        Task<int> MarkStudentTaskAsChecked(int studentTaskId);

        //ForTeacher
        Task<int> MarkStudentTaskAsNeededToBeRedone(int studentTaskId);

        //Common
        /*Task<int> EvaluateTask(int taskId, int grade); //authomatically markAsChecked
        Task<int> AddAttachment(int taskId, string url); // IAttachment
        Task<int> AddComment(); // CommentDto*/
    }
}
