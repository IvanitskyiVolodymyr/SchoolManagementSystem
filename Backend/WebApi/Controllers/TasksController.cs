using Application.Interfaces;
using Common.Dtos.StudentTaskAttachment;
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

        [HttpPost("student")]
        //Teacher
        public async Task<ActionResult<int>> CreateTaskForStudent([FromBody] InsertTaskDto taskDto, int studentId)
        {
            return Ok(await _taskService.InsertTaskForStudent(taskDto, studentId));
        }

        [HttpPost("students")]
        //Teacher
        public async Task<ActionResult<int>> CreateTaskForStudents([FromBody] InsertTaskDto taskDto)
        {
            return Ok(await _taskService.InsertTaskForStudentsByScheduleId(taskDto));
        }

        [HttpPost("{studentTaskId}/evaluate")]
        //Teacher
        public async Task<ActionResult<int>> EvaluateTask(int studentTaskId, int grade)
        {
            _tasksValidators.ValidateGrade(grade);
            return Ok(await _taskService.EvaluateTask(studentTaskId, grade));
        }

        [HttpPut("student-task")]
        //Teacher
        public async Task<ActionResult<int>> UpdateStudentTaskGrade(int studentTaskId, int grade)
        {
            _tasksValidators.ValidateGrade(grade);
            return Ok(await _taskService.UpdateStudentTaskGrade(studentTaskId, grade));
        }

        [HttpPut]
        //Teacher
        public async Task<ActionResult<int>> UpdateTask([FromBody] UpdateTaskDto task)
        {
            return Ok(await _taskService.UpdateTask(task));
        }

        [HttpPost("{studentTaskId}/submit")]
        public async Task<ActionResult<int>> SubmitStudentTask([FromBody] List<StudentTaskAttachmentDto> attachments, int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.SubmitStudentTask(studentTaskId, attachments));
        }

        [HttpPost("{studentTaskId}/cancel")]
        public async Task<ActionResult<int>> CancelSubmitStudentTask(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.CancelSubmitStudentTask(studentTaskId));
        }

        [HttpPut("{studentTaskId}/mark-as-checked")]
        //Teacher
        public async Task<ActionResult<int>> MarkStudentTaskAsChecked(int studentTaskId)
        {
            return Ok(await _taskService.MarkStudentTaskAsChecked(studentTaskId));
        }

        [HttpPut("{studentTaskId}/mark-as-needed-to-be-redone")]
        //Teacher
        public async Task<ActionResult<int>> MarkStudentTaskAsNeededToBeRedone(int studentTaskId)
        {
            return Ok(await _taskService.MarkStudentTaskAsNeededToBeRedone(studentTaskId));
        }

        [HttpGet("students/{studentId}/home-works")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllHomeworksForStudent(int studentId, DateTime from, DateTime to)
        {
            await _tasksValidators.CheckAccessByStudentId(studentId);
            return Ok(await _taskService.GetAllHomeworksForStudent(studentId, from, to));
        }

        [HttpGet("students/{studentId}")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetAllTasksForStudentByPeriod(int studentId, DateTime from, DateTime to)
        {
            await _tasksValidators.CheckAccessByStudentId(studentId);
            return Ok(await _taskService.GetAllTasksForStudentByPeriod(studentId, from, to));
        }

        [HttpGet("students/{studentId}/tasks-with-grades")]
        public async Task<ActionResult<IEnumerable<ResponseTaskWithGradeDto>>> GetAllTasksWithGradesForStudent(int studentId, DateTime from, DateTime to)
        {
            await _tasksValidators.CheckAccessByStudentId(studentId);
            return Ok(await _taskService.GetAllTasksWithGradesForStudent(studentId, from, to)); 
        }

        [HttpGet("teachers/{teacherId}")]
        public async Task<ActionResult<IEnumerable<ResponseTeacherTaskDto>>> GetUncheckedTasksByTeacherIdSubjectIdClassId(int teacherId, int subjectId, int classId)
        {
            return Ok(await _taskService.GetUncheckedTasksByTeacherIdSubjectIdClassId(teacherId, subjectId, classId));
        }

        [HttpGet("{studentTaskId}/attachments")]
        public async Task<ActionResult<IEnumerable<StudentTaskAttachmentDto>>> GetStudentTaskAttachments(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.GetStudentTaskAttachments(studentTaskId));
        }

        [HttpGet("{studentTaskId}/tasks-with-attachments")]
        public async Task<ActionResult<ResponseTaskWithGradeAndAttachmentsDto>> GetTaskWithStatusAndAttachments(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _taskService.GetTaskWithStatusAndAttachments(studentTaskId));
        }
    }
}
