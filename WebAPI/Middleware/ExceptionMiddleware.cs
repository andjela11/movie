using System.Net;
using System.Text.Json;
using Application.Exceptions;
using FluentValidation;
using WebAPI.Models;

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
        catch (ValidationException e)
        {
            var validationErrors = e.Errors.Where(x => x != null)
                .GroupBy(
                    x => x.PropertyName,
                    x => x.ErrorMessage,
                    (propertyName, errorMessages) => new
                    {
                        Key = propertyName,
                        Values = errorMessages.Distinct().ToArray()
                    })
                .ToDictionary(x => x.Key, x => x.Values);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

            var response = new
                ErrorDetails(context.Response.StatusCode, e.Message, "Validation Error", validationErrors);

            var json = JsonSerializer.Serialize(response,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true });

            await context.Response.WriteAsync(json);
        }
        catch (Exception e)
        {
            this._logger.LogError(e, e.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = this._env.IsDevelopment()
                ? new ErrorDetails(context.Response.StatusCode, e.Message, e.StackTrace, null)
                : new ErrorDetails(context.Response.StatusCode, e.Message, "Something went wrong", null);

            var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, opt);

            await context.Response.WriteAsync(json);
        }
    }
}
