using System.Net;

namespace Application.Auth.Exceptions
{
    public class MissingAccessTokenException : ResponseExceptionBase
    {
        public MissingAccessTokenException() : base(HttpStatusCode.Unauthorized, "Missing access token")
        {
        }
    }
}
