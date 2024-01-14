using pizzaProject.Middleware;
namespace pizzaProject.Extensions;
public static class ActionLogbMiddlewareExtension
{
    public static IApplicationBuilder UseActionLog(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ActionLogbMiddleware>();
    }
}