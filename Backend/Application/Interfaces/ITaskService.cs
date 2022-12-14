using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        //ForStudent
        Task<IEnumerable<ResponseTaskDto>> GetAllUncheckedTasksForStudent(int studentId);

        //ForStudent
        Task<IEnumerable<ResponseTaskDto>> GetAllHomeworksForStudent(int studentId, DateTime from, DateTime to);

        //ForStudent
        Task<IEnumerable<ResponseTaskDto>> GetAllTasksForStudentByPeriod(int studentId, DateTime from, DateTime to);

        //ForStudent
        Task<IEnumerable<ResponseTaskWithGradeDto>> GetAllTasksWithGradesForStudent(int studentId, DateTime from, DateTime to);
        Task<ResponseTaskWithGradeAndAttachmentsDto> GetTaskWithStatusAndAttachments(int studentTaskId);

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
        Task<int> CancelSubmitStudentTask(int studentTaskId);

        //ForTeacher
        Task<int> MarkStudentTaskAsChecked(int studentTaskId);

        //ForTeacher
        Task<int> MarkStudentTaskAsNeededToBeRedone(int studentTaskId);

        //ForTeacher
        Task<int> EvaluateTask(int studentTaskId, int grade);

        //ForTeacher
        Task<int> UpdateStudentTaskGrade(int studentTaskId, int grade);
    }
}
