using System.Net;

namespace Common.Exceptions.Auth
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
