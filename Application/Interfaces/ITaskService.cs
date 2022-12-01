using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        //ForStudent
        Task<IEnumerable<ResponseTaskDto>> GetAllUncheckedTasksForStudent(int studentId);

        //ForStudent
        Task<IEnumerable<ResponseTaskWithGradeDto>> GetAllCheckedTasksWithGradesForStudent(int studentId, DateTime from, DateTime to);

        //ForTeacher
        Task<IEnumerable<ResponseTeacherTaskDto>> GetUncheckedTasksByTeacherIdSubjectIdClassId(int teacherId, int subjectId, int classId);

        //ForTeacher
        Task<IEnumerable<StudentTaskAttachmentDto>> GetStudentTaskAttachments(int studentTaskId);

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

        //ForTeacher
        Task<int> EvaluateTask(int studentTaskId, int grade);

        //ForTeacher
        Task<int> UpdateStudentTaskGrade(int studentTaskId, int grade);
        /*Task<int> AddAttachment(int taskId, string url); // IAttachment
        Task<int> AddComment(); // CommentDto*/
    }
}
