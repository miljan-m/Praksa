using System.Text.Json;
using LibraryApp.CustomExceptions;
using LibraryApp.Constants;
namespace LibraryApp.Middlewares;

public class GlobalExceptionHandlingMiddleware
{

    private readonly ILogger<GlobalExceptionHandlingMiddleware> logger;
    private readonly RequestDelegate next;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, RequestDelegate next)
    {
        this.logger = logger;
        this.next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (InvalidArgumentException exception)
        {
            logger.LogError(exception, "Exception: {message}", exception.Message);
            var problemDetail = new ProblemDetails
            {
                Title = ConstantsClass.ExceptionErrors.InvalidArgumentException.Title,
                Type = ConstantsClass.ExceptionErrors.InvalidArgumentException.Type,
                Detail = ConstantsClass.ExceptionErrors.InvalidArgumentException.Details+exception.Message,
                Status = ConstantsClass.ExceptionErrors.InvalidArgumentException.Status

            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetail);

        }
        catch (NotFoundException exception)
        {
            logger.LogError(exception, "Neki exception: {message}", exception.Message);

            var problemDetail = new ProblemDetails
            {
                Title = ConstantsClass.ExceptionErrors.NotFoundException.Title,
                Type = ConstantsClass.ExceptionErrors.NotFoundException.Type,
                Detail = ConstantsClass.ExceptionErrors.NotFoundException.Details+exception.Message,
                Status=ConstantsClass.ExceptionErrors.NotFoundException.Status                
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetail);

        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Exception: {message}", exception.Message);

            var problemDetail = new ProblemDetails
            {
                Title = "Theres some kind of problem",
                Status = StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetail);

        }
    }
}