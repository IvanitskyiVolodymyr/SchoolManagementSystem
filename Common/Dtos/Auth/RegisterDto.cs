using Common.Dtos.Users;

namespace Common.Dtos.Auth
{
    public class RegisterDto : CreateUserDto
    {
        public int RoleId { get; set; }
    }
}
