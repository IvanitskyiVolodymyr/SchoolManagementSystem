using Common.Dtos.StudentTaskComment;

namespace Application.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<ResponseStudentTaskCommentDto>> GetCommentsByStudentTaskId(int studentTaskId);
        Task<ResponseStudentTaskCommentDto> CreateComment(CreateStudentTaskCommentDto comment);
        Task<ResponseStudentTaskCommentDto> UpdateComment(UpdateStudentTaskCommentDto comment);
    }
}
