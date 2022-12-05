namespace Common.Dtos.Users
{
    public class ResponseParentDto
    {
        public UserDto User { get; set; }
        public int ParentId { get; set; }
        public List<int> StudentIds { get; set; }
    }
}
