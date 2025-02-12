using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ServiceHost.Common.Middlewares;

public class JsonExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<JsonExceptionMiddleware> _logger;

    public JsonExceptionMiddleware(RequestDelegate next, ILogger<JsonExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (JsonException jsonEx)
        {
            _logger.LogError(jsonEx, "JSON conversion error occurred.");
            await HandleJsonExceptionAsync(context, jsonEx);
        }
    }

    private static async Task HandleJsonExceptionAsync(HttpContext context, JsonException exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        // Create an errors dictionary similar to FluentValidation's output.
        var errors = new Dictionary<string, string[]>
        {
            { "$", new[] { "Invalid value for one or more fields. " + exception.Message } }
        };

        var validationProblem = new ValidationProblemDetails(errors)
        {
            Title = "One or more validation errors occurred.",
            Status = 400,
            Detail = "Please review the errors and try again."
        };

        // Use System.Text.Json to serialize the ValidationProblemDetails
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters =
            {
                new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
            }
        };

        var jsonResponse = JsonSerializer.Serialize(validationProblem, options);
        await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
    }
}
