using System.Net;

namespace Common.Exceptions.Auth
{
    public class ExpiredRefreshTokenException : ResponseExceptionBase
    {
        public ExpiredRefreshTokenException() 
            : base(HttpStatusCode.Unauthorized, "Expired refresh token")
        { }
    }
}
