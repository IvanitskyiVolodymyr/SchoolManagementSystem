using System.Net;

namespace Application.Auth.Exceptions
{
    public class InvalidAccessTokenException : ResponseExceptionBase
    {
        public InvalidAccessTokenException() : base(HttpStatusCode.Unauthorized, "Invalid access token")
        {
        }
    }
}
