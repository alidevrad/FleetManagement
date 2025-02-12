using FleetManagement.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceHost.Common.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger,
                                       RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occurred: {Message}", ex.Message);

            var exceptionDetails = GetExceptionDetails(ex);

            var problemDetails = new ProblemDetails
            {
                Status = exceptionDetails.Status,
                Type = exceptionDetails.Type,
                Title = exceptionDetails.Title,
                Detail = exceptionDetails.Detail,
            };

            if (exceptionDetails.Erros is not null)
            {
                problemDetails.Extensions["errors"] = exceptionDetails.Erros;
            }

            context.Response.StatusCode = exceptionDetails.Status;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }

    private static ExceptionDetails GetExceptionDetails(Exception ex)
    {
        return ex switch
        {
            ValidationException validationException => new ExceptionDetails(StatusCodes.Status400BadRequest,
                                                                            "ValidationFailure",
                                                                            "Validation error",
                                                                            "One or more validation errors has occurred",
                                                                            validationException.Errors),
            _ => new ExceptionDetails(StatusCodes.Status500InternalServerError,
                                      "ServerError",
                                      "Server error",
                                      "An unexpected error has occurred",
                                      null)
        };
    }

    internal record ExceptionDetails(int Status,
                                     string Type,
                                     string Title,
                                     string Detail,
                                     IEnumerable<object>? Erros);
}
