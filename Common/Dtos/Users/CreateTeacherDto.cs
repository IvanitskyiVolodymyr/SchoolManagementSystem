namespace Common.Dtos.Users
{
    public class CreateTeacherDto : CreateUserDto
    {
        public int? ClassId { get; set; }
    }
}
