namespace WebAPI.Models;

public class ErrorDetails
{
    public ErrorDetails(int statusCode, string message, string? details, Dictionary<string, string[]>? validationErrors)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
        ValidationErrors = validationErrors;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string? Details { get; set; }

    public Dictionary<string, string[]>? ValidationErrors { get; set; }
}
