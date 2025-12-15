using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace OnlineQuizSystem.Middlewares;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlingMiddleware(RequestDelegate next)
    {
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
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var problem = CreateProblemDetails(exception);
        context.Response.StatusCode = (int)problem.Status!;
        context.Response.ContentType = "application/json";

        var result = JsonSerializer.Serialize(problem);
        await context.Response.WriteAsync(result);
    }

    private ProblemDetails CreateProblemDetails(Exception exception)
    {
        return exception switch
        {

            KeyNotFoundException => new ProblemDetails
            {
                Status = 404,
                Title = "Not Found",
                Detail = exception.Message
            },
            ValidationException => new ProblemDetails
            {
                Status = 400,
                Title = "Invalid Data",
                Detail = exception.Message
            },
            _ => new ProblemDetails
            {
                Status = 500,
                Title = "Server Error",
                Detail = "An unexpected error occurred"
            }
        };
    }
}
