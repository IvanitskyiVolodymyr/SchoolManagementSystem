using System.Net;

namespace Common.Exceptions
{
    public class NotAcceptableException : ResponseExceptionBase
    {
        public NotAcceptableException() : base(HttpStatusCode.NotAcceptable, "Do not have access")
        {

        }
    }
}
