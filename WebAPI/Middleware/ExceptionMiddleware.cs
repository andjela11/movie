using System.Net;
using System.Text.Json;
using Application.Exceptions;
using WebAPI.Error;

namespace WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        this._next = next;
        this._logger = logger;
        this._env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            //_logger.LogDebug(JsonSerializer.Serialize(context.Request.Body));
            await this._next(context);
            //_logger.LogDebug(JsonSerializer.Serialize(context.Response.Body));
        }
        catch (MoreThanOneMovieException e)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        catch (Exception e)
        {
            this._logger.LogError(e, e.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = this._env.IsDevelopment()
                ? new ErrorDetails(context.Response.StatusCode, e.Message, e.StackTrace)
                : new ErrorDetails(context.Response.StatusCode, e.Message, "Something went wrong");

            var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, opt);

            await context.Response.WriteAsync(json);
        }
    }
}
