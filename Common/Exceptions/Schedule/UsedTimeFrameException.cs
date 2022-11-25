using System.Net;

namespace Common.Exceptions.Schedule
{
    public class UsedTimeFrameException : ResponseExceptionBase
    {
        public UsedTimeFrameException() 
            : base(HttpStatusCode.BadRequest, "This time frame has already been used")
        {
        }
    }
}
