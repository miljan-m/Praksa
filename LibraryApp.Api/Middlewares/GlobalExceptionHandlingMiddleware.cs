using LibraryApp.CustomExceptions;
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
                Title = ExceptionConstants.ExceptionConstants.ExceptionErrors.InvalidArgumentException.Title,
                Type = ExceptionConstants.ExceptionConstants.ExceptionErrors.InvalidArgumentException.Type,
                Detail = ExceptionConstants.ExceptionConstants.ExceptionErrors.InvalidArgumentException.Details+exception.Message,
                Status = ExceptionConstants.ExceptionConstants.ExceptionErrors.InvalidArgumentException.Status

            };

            context.Response.StatusCode = ExceptionConstants.ExceptionConstants.ExceptionErrors.InvalidArgumentException.Status;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetail);

        }
        catch (NotFoundException exception)
        {
            logger.LogError(exception, "Exception: {message}", exception.Message);

            var problemDetail = new ProblemDetails
            {
                Title = ExceptionConstants.ExceptionConstants.ExceptionErrors.NotFoundException.Title,
                Type = ExceptionConstants.ExceptionConstants.ExceptionErrors.NotFoundException.Type,
                Detail = ExceptionConstants.ExceptionConstants.ExceptionErrors.NotFoundException.Details+exception.Message,
                Status=ExceptionConstants.ExceptionConstants.ExceptionErrors.NotFoundException.Status                
            };


            context.Response.StatusCode = ExceptionConstants.ExceptionConstants.ExceptionErrors.NotFoundException.Status;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetail);

        }
        catch (Exception exception)
        {
            logger.LogError(exception, "Exception: {message}", exception.Message);

            var problemDetail = new ProblemDetails
            {
                Title = ExceptionConstants.ExceptionConstants.ExceptionErrors.UndefinedError.Title,
                Type = ExceptionConstants.ExceptionConstants.ExceptionErrors.UndefinedError.Type,
                Detail = ExceptionConstants.ExceptionConstants.ExceptionErrors.UndefinedError.Details+exception.Message,
                Status=ExceptionConstants.ExceptionConstants.ExceptionErrors.UndefinedError.Status  
            };

            context.Response.StatusCode = ExceptionConstants.ExceptionConstants.ExceptionErrors.UndefinedError.Status;

            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(problemDetail);

        }
    }
}