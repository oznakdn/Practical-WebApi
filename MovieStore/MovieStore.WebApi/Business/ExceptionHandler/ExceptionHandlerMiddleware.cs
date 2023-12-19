using MovieStore.WebApi.Business.Logger;
using Newtonsoft.Json;
using System.Net;

namespace MovieStore.WebApi.Business.ExceptionHandler
{
    public class ExceptionHandlerMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next = next;
            _loggerService = loggerService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                string message = $"[Request] HTTP Method: {httpContext.Request.Method} Path: {httpContext.Request.Path} Time:{DateTime.Now}";
                _loggerService.WriteLog(message);

                await _next(httpContext);

                message = $"[Response] HTTP Method: {httpContext.Request.Method} Path: {httpContext.Request.Path} StatusCode: {httpContext.Response.StatusCode} Time:{DateTime.Now}";
                _loggerService.WriteLog(message);

            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex);
            }
        }
        private Task HandleException(HttpContext context, Exception ex)
        {

            context.Response.ContentType = "application/jason";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = $"[Error] HTTP Method: {context.Request.Method} StatusCode: {context.Response.StatusCode} Error Message: {ex.Message} Time:{DateTime.Now}";
            _loggerService.WriteLog(message);


            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.None);

            return context.Response.WriteAsync(result);
        }

    }
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
