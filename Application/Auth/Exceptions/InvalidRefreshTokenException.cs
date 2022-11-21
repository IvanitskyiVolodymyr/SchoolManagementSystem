using System.Net;

namespace Application.Auth.Exceptions
{
    public class InvalidRefreshTokenException : ResponseExceptionBase
    {
        public InvalidRefreshTokenException() 
            : this("Invalid refresh token")
        { }

        public InvalidRefreshTokenException(string message)
            : base(HttpStatusCode.Unauthorized, message)
        { }
    }
}
