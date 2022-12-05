using System.Net;

namespace Common.Exceptions
{
    public class NotFoundException : ResponseExceptionBase
    {
        public NotFoundException(Type type, string valueName, string value) 
            : base(HttpStatusCode.BadRequest, $"{type.Name} with {valueName} = {value} not found")
        { }
    }
}
