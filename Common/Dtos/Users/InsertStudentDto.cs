namespace Common.Dtos.Users
{
    public class InsertStudentDto
    {
        public int UserId { get; set; }
        public int? ClassId { get; set; }
        public int StudentCode { get; set; }
    }
}
