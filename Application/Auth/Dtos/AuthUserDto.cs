using Application.Users.Dtos;

namespace Application.Auth.Dtos
{
    public class AuthUserDto
    {
        public UserDto User { get; set; }
        public TokenModel Tokens{ get; set; }
    }
}
