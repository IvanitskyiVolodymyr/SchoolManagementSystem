using Common.Dtos.Users;

namespace Common.Dtos.StudentTaskComment
{
    public class ResponseStudentTaskCommentDto
    {
        public int StudentTaskCommentId { get; set; }
        public int CommentParentId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ShortUserInfoDto ShortUserInfo { get; set; }
    }
}
