namespace Common.Dtos.Users
{
    public class CreateParentDto : CreateUserDto
    {
        public List<int> StudentIds { get; set; }
    }
}
