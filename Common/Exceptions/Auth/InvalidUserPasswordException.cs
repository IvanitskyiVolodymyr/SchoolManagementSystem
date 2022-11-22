using System.Net;

namespace Common.Exceptions.Auth
{
    public class InvalidUserPasswordException : ResponseExceptionBase
    {
        public InvalidUserPasswordException() 
            : base(HttpStatusCode.BadRequest, "User email or password do not match")
        {
        }
    }
}
