namespace Application.Auth.Dtos
{
    public class AuthUserDto
    {
        public UserDto User { get; set; }
        public string AccessToken { get; set; }
    }
}
