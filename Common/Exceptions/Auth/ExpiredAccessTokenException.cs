using System.Net;

namespace Common.Exceptions.Auth
{
    public class ExpiredAccessTokenException : ResponseExceptionBase
    {
        public ExpiredAccessTokenException() : base(HttpStatusCode.Unauthorized, "Access token expired")
        { }
    }
}
