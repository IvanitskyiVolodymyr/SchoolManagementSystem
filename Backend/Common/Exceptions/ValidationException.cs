using System.Net;

namespace Common.Exceptions
{
    public class ValidationException : ResponseExceptionBase
    {
        public ValidationException(string message) 
            : base(HttpStatusCode.BadRequest, message)
        {

        }
    }
}
