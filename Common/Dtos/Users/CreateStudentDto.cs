namespace Common.Dtos.Users
{
    public class CreateStudentDto : CreateUserDto
    {
        public int? ClassId { get; set; }
        public int StudentCode { get; set; }
    }
}
