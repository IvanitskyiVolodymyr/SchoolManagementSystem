using System.Net;

namespace Common.Exceptions.Auth
{
    public class MissingAccessTokenException : ResponseExceptionBase
    {
        public MissingAccessTokenException() : base(HttpStatusCode.Unauthorized, "Missing access token")
        {
        }
    }
}
