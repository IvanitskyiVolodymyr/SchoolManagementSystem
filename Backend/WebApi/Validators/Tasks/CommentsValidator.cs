using Application.Interfaces;
using Common.Dtos.StudentTaskComment;
using Common.Exceptions;
using Domain.Interfaces.Repositories;

namespace WebApi.Validators.Tasks
{
    public class CommentsValidator
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IStudentTaskCommentRepository _commentRepository;

        public CommentsValidator(IStudentTaskCommentRepository commentResository, ICurrentUserService currentUserService)
        {
            _commentRepository = commentResository;
            _currentUserService = currentUserService;
        }

        public async Task CheckAccessByStudentTaskCommentId(int studentTaskCommentId)
        {
            int currentUserId = _currentUserService.GetCurrentUserId();

            var studentCommentTask = await _commentRepository.GetCommentsByStudentTaskCommentId(studentTaskCommentId);
            if (studentCommentTask is null)
            {
                throw new NotFoundException(typeof(ResponseStudentTaskCommentDto), "StudentTaskCommentId", studentTaskCommentId.ToString());
            }

            if(currentUserId != studentCommentTask.ShortUserInfo.UserId)
            {
                throw new NotAcceptableException();
            }
        }

        public async Task CheckUpdateDeletePermission(int studentTaskCommentId)
        {
            var studentCommentTask = await _commentRepository.GetCommentsByStudentTaskCommentId(studentTaskCommentId);
            var dateDiff = DateTime.Now - studentCommentTask.CreatedAt;

            if(dateDiff > TimeSpan.FromMinutes(5))
            {
                throw new ValidationException("You cannot delete or update a comment after 5 minutes from the time it was created");
            }
        }
    }
}
