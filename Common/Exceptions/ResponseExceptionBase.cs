using System.Net;
using System.Text.Json;

namespace Common.Exceptions
{
    public class ResponseExceptionBase : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public ResponseExceptionBase(HttpStatusCode statusCode, string errorMessage)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(new ExceptionInfo(StatusCode.ToString(), ErrorMessage));
        }
    }
}
