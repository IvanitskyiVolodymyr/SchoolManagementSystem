using Common.Dtos.Users;

namespace Common.Dtos.Auth
{
    public class AuthUserDto
    {
        public UserDto User { get; set; }
        public TokenModel Tokens{ get; set; }
    }
}
