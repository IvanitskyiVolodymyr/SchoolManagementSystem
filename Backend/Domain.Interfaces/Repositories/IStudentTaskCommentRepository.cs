using Common.Dtos.StudentTaskComment;

namespace Domain.Interfaces.Repositories
{
    public interface IStudentTaskCommentRepository
    {
        Task<IEnumerable<ResponseStudentTaskCommentDto>> GetCommentsByStudentTaskId(int studentTaskId);
        Task<int> CreateComment(CreateStudentTaskCommentDto comment);
        Task<int> UpdateComment(UpdateStudentTaskCommentDto comment);
    }
}
