using System.Diagnostics;
using System.Globalization;
using FileService;

namespace pizzaProject.Middleware;

public class ActionLogbMiddleware
{
    private readonly RequestDelegate _next;
    public ILog _logService{get;set;}
    public ActionLogbMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,ILog logService)
    {
        _logService=logService;
        logService.WriteMessage(DateTime.Now);
        logService.WriteMessage("---------");
        logService.WriteMessage(context.Request.Method);
        logService.WriteMessage("---------");
        logService.WriteMessage(context.Request.Body);
        logService.WriteMessage("---------");
        logService.WriteMessage(context.Request.Headers);
        logService.WriteMessage("---------");
        logService.WriteMessage(context.Request.Path);
        logService.WriteMessage("---------");
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
        logService.WriteMessage(DateTime.Now);
        logService.WriteMessage(context.Response.StatusCode);
        logService.WriteMessage(context.Response.Body);
        
    }
}
