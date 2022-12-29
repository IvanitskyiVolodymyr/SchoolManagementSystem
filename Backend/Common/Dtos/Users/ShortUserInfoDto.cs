namespace Common.Dtos.Users
{
    public class ShortUserInfoDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public int RoleId { get; set; }
    }
}
