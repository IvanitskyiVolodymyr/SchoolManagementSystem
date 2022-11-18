using System.Net;

namespace Application.Auth.Exceptions
{
    public class ExpiredAccessTokenException : ResponseExceptionBase
    {
        public ExpiredAccessTokenException() : base(HttpStatusCode.Unauthorized, "Access token expired")
        { }
    }
}
