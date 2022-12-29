using Application.Interfaces;
using Common.Dtos.StudentTaskAttachment;
using Common.Dtos.StudentTaskComment;
using Common.Dtos.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Validators.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly TasksValidators _tasksValidators;

        public TasksController(ITaskService taskService, TasksValidators tasksValidators)
        {
            _taskService = taskService;
            _tasksValidators = tasksValidators;
        }

        [HttpPost("CreateTaskForStudent")]
        //Teacher
        public async Task<ActionResult<int>> CreateTaskForStudent([FromBody] InsertTaskDto taskDto, int studentId)
        {
            return Ok(await _taskService.InsertTaskForStudent(taskDto, studentId));
        }

        [HttpPost("CreateTaskForStudentsByScheduleId")]
        //Teacher
        public async Task<ActionResult<int>> CreateTaskForStudents([FromBody] InsertTaskDto taskDto)
        {
            return Ok(await _taskService.InsertTaskForStudentsByScheduleId(taskDto));
        }

        [HttpPost("EvaluateTask")]
        //Teacher
        public async Task<ActionResult<int>> EvaluateTask(int studentTaskId, int grade)
        {
            _tasksValidators.ValidateGrade(grade);
            return Ok(await _taskService.EvaluateTask(studentTaskId, grade));
        }

        [HttpPut("UpdateStudentTaskGrade")]
        //Teacher
        public async Task<ActionResult<int>> UpdateStudentTaskGrade(int studentTaskId, int grade)
        {
            _tasksValidators.ValidateGrade(grade);
            return Ok(await _taskService.UpdateStudentTaskGrade(studentTaskId, grade));
        }

        [HttpPut("UpdateTask")]
        //Teacher
        public async Task<ActionResult<int>> UpdateTask([FromBody] UpdateTaskDto task)
        {
            return Ok(await _taskService.UpdateTask(task));
        }

        [HttpPost("SubmitStudentTask")]
        public async Task<ActionResult<int>> SubmitStudentTask([FromBody] List<StudentTaskAttachmentDto> attachments, int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.SubmitStudentTask(studentTaskId, attachments));
        }

        [HttpPost("CancelSubmitStudentTask")]
        public async Task<ActionResult<int>> CancelSubmitStudentTask(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.CancelSubmitStudentTask(studentTaskId));
        }

        [HttpPut("MarkStudentTaskAsChecked")]
        //Teacher
        public async Task<ActionResult<int>> MarkStudentTaskAsChecked(int studentTaskId)
        {
            return Ok(await _taskService.MarkStudentTaskAsChecked(studentTaskId));
        }

        [HttpPut("MarkStudentTaskAsNeededToBeRedone")]
        //Teacher
        public async Task<ActionResult<int>> MarkStudentTaskAsNeededToBeRedone(int studentTaskId)
        {
            return Ok(await _taskService.MarkStudentTaskAsNeededToBeRedone(studentTaskId));
        }

        [HttpGet("GetAllHomeworksForStudent")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllHomeworksForStudent(int studentId, DateTime from, DateTime to)
        {
            await _tasksValidators.CheckAccessByStudentId(studentId);
            return Ok(await _taskService.GetAllHomeworksForStudent(studentId, from, to));
        }

        [HttpGet("GetAllTasksForStudentByPeriod")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllTasksForStudentByPeriod(int studentId, DateTime from, DateTime to)
        {
            await _tasksValidators.CheckAccessByStudentId(studentId);
            return Ok(await _taskService.GetAllTasksForStudentByPeriod(studentId, from, to));
        }

        [HttpGet("GetAllTasksWithGradesForStudent")]
        public async Task<ActionResult<IEnumerable<ResponseTaskWithGradeDto>>> GetAllTasksWithGradesForStudent(int studentId, DateTime from, DateTime to)
        {
            await _tasksValidators.CheckAccessByStudentId(studentId);
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
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.GetStudentTaskAttachments(studentTaskId));
        }

        [HttpGet("GetTaskWithStatusAndAttachments")]
        public async Task<ActionResult<ResponseTaskWithGradeAndAttachmentsDto>> GetTaskWithStatusAndAttachments(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.GetTaskWithStatusAndAttachments(studentTaskId));
        }

        [HttpGet("GetCommentsByStudentTaskId")]
        public async Task<ActionResult<ResponseTaskWithGradeAndAttachmentsDto>> GetCommentsByStudentTaskId(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.GetCommentsByStudentTaskId(studentTaskId));
        }

        [HttpPost("CreateComment")]
        public async Task<ActionResult<int>> CreateComment([FromBody] CreateStudentTaskCommentDto comment)
        {
            return Ok(await _taskService.CreateComment(comment));
        }

        [HttpPut("UpdateComment")]
        public async Task<ActionResult<int>> UpdateComment([FromBody] UpdateStudentTaskCommentDto comment)
        {
            return Ok(await _taskService.UpdateComment(comment));
        }

    }
}
