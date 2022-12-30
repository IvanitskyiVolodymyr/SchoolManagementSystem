using Application.Interfaces;
using Common.Dtos.StudentTaskComment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using WebApi.Validators.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly TasksValidators _tasksValidators;
        private readonly CommentsValidator _commentsValidators;
        private readonly ICommentService _commentService;

        public CommentsController(TasksValidators tasksValidators, ICommentService commentService, CommentsValidator commentsValidators)
        {
            _tasksValidators = tasksValidators;
            _commentService = commentService;
            _commentsValidators = commentsValidators;
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
            await _commentsValidators.CheckAccessByStudentTaskCommentId(comment.StudentTaskCommentId);
            await _commentsValidators.CheckUpdateDeletePermission(comment.StudentTaskCommentId);
            return Ok(await _commentService.UpdateComment(comment));
        }

        [HttpDelete("delete-comment")]
        public async Task<ActionResult<int>> DeleteComment(int studentTaskCommentId)
        {
            await _commentsValidators.CheckAccessByStudentTaskCommentId(studentTaskCommentId);
            await _commentsValidators.CheckUpdateDeletePermission(studentTaskCommentId);
            return Ok(await _commentService.DeleteComment(studentTaskCommentId));
        }
    }
}
