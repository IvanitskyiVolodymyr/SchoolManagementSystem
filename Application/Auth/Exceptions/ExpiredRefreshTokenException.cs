using System.Net;

namespace Application.Auth.Exceptions
{
    public class ExpiredRefreshTokenException : ResponseExceptionBase
    {
        public ExpiredRefreshTokenException() 
            : base(HttpStatusCode.Unauthorized, "Expired refresh token")
        { }
    }
}
