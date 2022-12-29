using Application.Interfaces;
using Common.Dtos.StudentTaskComment;
using Domain.Interfaces.Repositories;

namespace Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IStudentTaskCommentRepository _studentTaskCommentRepository;

        public CommentService(IStudentTaskCommentRepository studentTaskCommentRepository)
        {
            _studentTaskCommentRepository = studentTaskCommentRepository;
        }

        public async Task<IEnumerable<ResponseStudentTaskCommentDto>> GetCommentsByStudentTaskId(int studentTaskId)
        {
            return await _studentTaskCommentRepository.GetCommentsByStudentTaskId(studentTaskId);
        }

        public async Task<ResponseStudentTaskCommentDto> CreateComment(CreateStudentTaskCommentDto comment)
        {
            var studentTaskCommentId = await _studentTaskCommentRepository.CreateComment(comment);
            var addedComment = await _studentTaskCommentRepository.GetCommentsByStudentTaskCommentId(studentTaskCommentId);
            if (addedComment is null)
                throw new Exception("Error occured while creating StudentTaskComment");

            return addedComment;
        }

        public async Task<ResponseStudentTaskCommentDto> UpdateComment(UpdateStudentTaskCommentDto comment)
        {
            var studentTaskCommentId = await _studentTaskCommentRepository.UpdateComment(comment);
            var updatedComment = await _studentTaskCommentRepository.GetCommentsByStudentTaskCommentId(studentTaskCommentId);
            if (updatedComment is null)
                throw new Exception("Error occured while creating StudentTaskComment");

            return updatedComment;
        }
    }
}
