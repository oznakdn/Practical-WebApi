using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using BookStore.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookStore.WebApi.Middlewares
{

    // Logalama yapmak için yani hangi metodun kullanıldığını console'da görebilmek için bu middleware'i yazdık.
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerService _loggerService;
        public CustomExceptionMiddleware(RequestDelegate next, ILoggerService loggerService)
        {
            _next=next;
            _loggerService=loggerService;
        }

        public async Task Invoke(HttpContext context)
        {
             var watch=Stopwatch.StartNew(); // Requesten response'a kadar geçen süreyi görmek için ==>Başlangıç

            try
            {
                // Requestler için
                string message="[Request] HTTP" + context.Request.Method + "-"+ context.Request.Path;
                _loggerService.Write(message);
                await _next(context);

                // Response'lar için
                watch.Stop();   // ===> Bitiş

                message="[Response] HTTP" + context.Request.Method + "-" + context.Request.Path +" "+ "responded" +" "+ context.Response.StatusCode + " " +
                "in" + " " + watch.Elapsed.Milliseconds +" "+ "ms";  // request-response arası geçen süreyi milisaniye cinsinden loglar.
                _loggerService.Write(message);
            }
            catch (Exception ex)
            {
                watch.Stop();
                await HandleException(context, ex, watch);
            }
            
        }

        private Task HandleException(HttpContext context, Exception ex, Stopwatch watch)
        {

            context.Response.ContentType="application/jason";
            context.Response.StatusCode=(int)HttpStatusCode.InternalServerError;

            string message="[Error] HTTP" +" " + context.Request.Method + " " + context.Response.StatusCode +" "+ "Error Message:"+ ex.Message +" "+"in" +" "+"ms"+" "+ watch.Elapsed.Milliseconds;
            _loggerService.Write(message);


            var result=JsonConvert.SerializeObject(new{error=ex.Message},Formatting.None);

            return context.Response.WriteAsync(result);
        }
    }

    public static class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}