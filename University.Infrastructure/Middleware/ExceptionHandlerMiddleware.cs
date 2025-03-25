using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace University.Infrastructure.Middleware;

public class ExceptionHandlerMiddleware(
    ILogger<ExceptionHandlerMiddleware> logger,
    IExceptionToResponseMapper exceptionToResponseMapper) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, ex.Message);
            await HandleException(context, ex);
        }
    }

    private async Task HandleException(
        HttpContext context,
        Exception exception)
    {
        var exceptionResponse = exceptionToResponseMapper.Map(exception);
        context.Response.StatusCode = (int)exceptionResponse.StatusCode;
        context.Response.ContentType = "application/json";
        await JsonSerializer.SerializeAsync(context.Response.Body, exceptionResponse.Data);
    }
}
