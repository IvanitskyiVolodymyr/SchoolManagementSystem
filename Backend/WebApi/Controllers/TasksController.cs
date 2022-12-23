using Application.Interfaces;
using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("CreateTaskForStudent")]
        public async Task<ActionResult<int>> CreateTaskForStudent([FromBody] InsertTaskDto taskDto, int studentId)
        {
            return Ok(await _taskService.InsertTaskForStudent(taskDto, studentId));
        }

        [HttpPost("CreateTaskForStudentsByScheduleId")]
        public async Task<ActionResult<int>> CreateTaskForStudents([FromBody] InsertTaskDto taskDto)
        {
            return Ok(await _taskService.InsertTaskForStudentsByScheduleId(taskDto));
        }

        [HttpPost("EvaluateTask")]
        public async Task<ActionResult<int>> EvaluateTask(int studentTaskId, int grade)
        {
            return Ok(await _taskService.EvaluateTask(studentTaskId, grade));
        }

        [HttpPut("UpdateStudentTaskGrade")]
        public async Task<ActionResult<int>> UpdateStudentTaskGrade(int studentTaskId, int grade)
        {
            return Ok(await _taskService.UpdateStudentTaskGrade(studentTaskId, grade));
        }

        [HttpPut("UpdateTask")]
        public async Task<ActionResult<int>> UpdateTask([FromBody] UpdateTaskDto task)
        {
            return Ok(await _taskService.UpdateTask(task));
        }

        [HttpPost("SubmitStudentTask")]
        public async Task<ActionResult<int>> SubmitStudentTask([FromBody] List<StudentTaskAttachmentDto> attachments, int studentTaskId)
        {
            return Ok(await _taskService.SubmitStudentTask(studentTaskId, attachments));
        }

        [HttpPost("CancelSubmitStudentTask")]
        public async Task<ActionResult<int>> CancelSubmitStudentTask(int studentTaskId)
        {
            return Ok(await _taskService.CancelSubmitStudentTask(studentTaskId));
        }

        [HttpPut("MarkStudentTaskAsChecked")]
        public async Task<ActionResult<int>> MarkStudentTaskAsChecked(int studentTaskId)
        {
            return Ok(await _taskService.MarkStudentTaskAsChecked(studentTaskId));
        }

        [HttpPut("MarkStudentTaskAsNeededToBeRedone")]
        public async Task<ActionResult<int>> MarkStudentTaskAsNeededToBeRedone(int studentTaskId)
        {
            return Ok(await _taskService.MarkStudentTaskAsNeededToBeRedone(studentTaskId));
        }

        [HttpGet("GetAllUncheckedTasksForStudent")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllUncheckedTasksForStudent(int studentId)
        {
            return Ok(await _taskService.GetAllUncheckedTasksForStudent(studentId));
        }

        [HttpGet("GetAllHomeworksForStudent")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllHomeworksForStudent(int studentId, DateTime from, DateTime to)
        {
            return Ok(await _taskService.GetAllHomeworksForStudent(studentId, from, to));
        }

        [HttpGet("GetAllTasksForStudentByPeriod")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllTasksForStudentByPeriod(int studentId, DateTime from, DateTime to)
        {
            return Ok(await _taskService.GetAllTasksForStudentByPeriod(studentId, from, to));
        }

        [HttpGet("GetAllTasksWithGradesForStudent")]
        public async Task<ActionResult<IEnumerable<ResponseTaskWithGradeDto>>> GetAllTasksWithGradesForStudent(int studentId, DateTime from, DateTime to)
        {
            return Ok(await _taskService.GetAllTasksWithGradesForStudent(studentId, from, to)); 
        }

        [HttpGet("GetUncheckedTasksByTeacherIdSubjectIdClassId")]
        public async Task<ActionResult<IEnumerable<ResponseTeacherTaskDto>>> GetUncheckedTasksByTeacherIdSubjectIdClassId(int teacherId, int subjectId, int classId)
        {
            return Ok(await _taskService.GetUncheckedTasksByTeacherIdSubjectIdClassId(teacherId, subjectId, classId));
        }

        [HttpGet("GetStudentTaskAttachments")]
        public async Task<ActionResult<IEnumerable<StudentTaskAttachmentDto>>> GetStudentTaskAttachments(int studentTaskId)
        {
            return Ok(await _taskService.GetStudentTaskAttachments(studentTaskId));
        }

        [HttpGet("GetTaskWithStatusAndAttachments")]
        public async Task<ActionResult<ResponseTaskWithGradeAndAttachmentsDto>> GetTaskWithStatusAndAttachments(int studentTaskId)
        {
            return Ok(await _taskService.GetTaskWithStatusAndAttachments(studentTaskId));
        }
    }
}
