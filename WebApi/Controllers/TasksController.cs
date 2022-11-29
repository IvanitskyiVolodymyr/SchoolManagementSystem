using Application.Interfaces;
using Common.Dtos.StudentTask;
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

        [HttpGet("GetTasksByStudentId")]
        public async Task<ActionResult<IEnumerable<ResponseTaskDto>>> GetTasksByStudentId(int studentId, DateTime from, DateTime to)
        {
            return Ok(await _taskService.GetTasksByStudentId(studentId, from, to));
        }
    }
}
