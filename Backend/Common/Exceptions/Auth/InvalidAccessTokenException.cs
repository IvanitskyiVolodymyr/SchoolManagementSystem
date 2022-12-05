using System.Net;

namespace Common.Exceptions.Auth
{
    public class InvalidAccessTokenException : ResponseExceptionBase
    {
        public InvalidAccessTokenException() : base(HttpStatusCode.Unauthorized, "Invalid access token")
        {
        }
    }
}
