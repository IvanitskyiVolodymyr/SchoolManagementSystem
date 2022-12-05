namespace Common.Exceptions
{
    public class ExceptionInfo
    {
        public string StatusCode { get; set; }
        public string Message { get; set; }

        public ExceptionInfo(string statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
