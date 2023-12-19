using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace SingerSong.Application.GlobalException;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    public GlobalExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {

            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var response = context.Response;
        var responseModel = new ExceptionResponse();

        switch (exception)
        {
            case ApplicationException:
                responseModel.StatusCode = (int)HttpStatusCode.BadRequest;
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                responseModel.ExceptionMessage = "Application Exception Occured! Please retry after sometime.";
                break;
            case FileNotFoundException:
                responseModel.StatusCode = (int)HttpStatusCode.NotFound;
                response.StatusCode = (int)HttpStatusCode.NotFound;
                responseModel.ExceptionMessage = "The request resource is not found!";
                break;

            default:
                responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                responseModel.ExceptionMessage = "Internal Server Error! Please retry after sometime.";
                break;
        }

        var exResult = JsonSerializer.Serialize(responseModel);
        await context.Response.WriteAsync(exResult);
    }
}

