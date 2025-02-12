using Microsoft.AspNetCore.Builder;

namespace ServiceHost.Common.Middlewares;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app)
    {
        app.UseMiddleware<JsonExceptionMiddleware>();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        return app;
    }
}