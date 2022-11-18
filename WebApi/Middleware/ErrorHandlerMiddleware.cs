using Application.Auth.Exceptions;
using System.Net;

namespace WebApi.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(ResponseExceptionBase exeption)
            {
                await HandleExceptionAsync(httpContext, exeption);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext, new ResponseExceptionBase(HttpStatusCode.InternalServerError, exception.Message));
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, ResponseExceptionBase exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;
            await context.Response.WriteAsync(exception.ToString());
        }
    }
}
