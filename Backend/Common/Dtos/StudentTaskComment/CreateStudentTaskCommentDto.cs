namespace Common.Dtos.StudentTaskComment
{
    public class CreateStudentTaskCommentDto
    {
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int StudentTaskId { get; set; }
        public int CommentParentId { get; set; }
    }
}
