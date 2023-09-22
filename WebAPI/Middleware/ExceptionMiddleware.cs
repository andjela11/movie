using System.Net;
using System.Runtime.InteropServices;
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

            await GenerateExceptionResponse(e, context, (int)HttpStatusCode.UnprocessableEntity, "Validation error", validationErrors);
        }
        catch (EntityNotFoundException e)
        {
            await GenerateExceptionResponse(e, context, (int)HttpStatusCode.NotFound, "No entity with the given parameter was found");
        }
        catch (Exception e)
        {
            this._logger.LogError(e, e.Message);

            await GenerateExceptionResponse(e, context, (int)HttpStatusCode.InternalServerError, "Something went wrong");
        }
    }

    private async Task GenerateExceptionResponse(
        Exception e,
        HttpContext context,
        int statusCode,
        string details,
        [Optional] Dictionary<string, string[]> validationErrors)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new ErrorDetails(context.Response.StatusCode, e.Message, details);

        if (validationErrors is not null)
        {
            response.ValidationErrors = validationErrors;
        }

        var opt = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        var json = JsonSerializer.Serialize(response, opt);

        await context.Response.WriteAsync(json);
    }
}
