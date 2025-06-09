using System.Reflection;
using Azure.Core;

namespace LibraryApp.Middlewares;

public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate next;
    private readonly ILogger<RequestResponseLoggingMiddleware> logger;
    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        this.next = next;
        this.logger = logger;
    }


    public async Task InvokeAsync(HttpContext context)
    {   if ((context.Request.Method == HttpMethods.Get || context.Request.Method == HttpMethods.Post
    || context.Request.Method == HttpMethods.Delete ||context.Request.Method == HttpMethods.Put) && (context.Request.Path.StartsWithSegments("/authors")
    || context.Request.Path.StartsWithSegments("/books") || context.Request.Path.StartsWithSegments("/admins")
     || context.Request.Path.StartsWithSegments("/customers"))  )
        {
            context.Request.EnableBuffering();
            context.Request.Body.Position = 0;
            using var requestBodyStream = new StreamReader(context.Request.Body, leaveOpen: true);
            string requestBodyText = await requestBodyStream.ReadToEndAsync();
            context.Request.Body.Position = 0;

            var headers = context.Request.Headers.Select(h=>$"{h.Key}:{h.Value}").ToList();
            logger.LogInformation("{Headers}\n", string.Join("\n", headers));

            logger.LogInformation("Request Body: {requestBodyText}", requestBodyText);

            var originalResponseBodyStream = context.Response.Body;
            using var tempStream = new MemoryStream();
            context.Response.Body = tempStream;

            await next(context);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            using var responseBodyStream = new StreamReader(context.Response.Body);
            string responseBodyText = await responseBodyStream.ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            logger.LogInformation("Response Body: {responseBodyText}", responseBodyText);
            context.Response.Body = originalResponseBodyStream;
            await tempStream.CopyToAsync(context.Response.Body);
        }
        else
        {
            await next(context);
        }
       
        
        
        
    }

}