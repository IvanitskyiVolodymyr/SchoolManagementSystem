using Application.Interfaces;
using Common.Dtos.StudentTaskComment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Validators.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly TasksValidators _tasksValidators;
        private readonly ICommentService _commentService;

        public CommentsController(TasksValidators tasksValidators, ICommentService commentService)
        {
            _tasksValidators = tasksValidators;
            _commentService = commentService;
        }

        [HttpGet("get-comments-by-student-task-id")]
        public async Task<ActionResult<ResponseStudentTaskCommentDto>> GetCommentsByStudentTaskId(int studentTaskId)
        {
            await _tasksValidators.CheckAccessByStudentTaskId(studentTaskId);
            return Ok(await _commentService.GetCommentsByStudentTaskId(studentTaskId));
        }

        [HttpPost("create-comment")]
        public async Task<ActionResult<ResponseStudentTaskCommentDto>> CreateComment([FromBody] CreateStudentTaskCommentDto comment)
        {
            return Ok(await _commentService.CreateComment(comment));
        }

        [HttpPut("update-comment")]
        public async Task<ActionResult<ResponseStudentTaskCommentDto>> UpdateComment([FromBody] UpdateStudentTaskCommentDto comment)
        {
            return Ok(await _commentService.UpdateComment(comment));
        }
    }
}
