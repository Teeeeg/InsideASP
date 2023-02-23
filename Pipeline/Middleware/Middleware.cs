namespace Pipeline.Middleware;

public static class Middleware
{
    public static RequestDelegate Middleware1(RequestDelegate next)
    {
        async Task RequestDelegate(HttpContext context)
        {
            await context.Response.WriteAsync("Hello");
            await next(context);
        }

        return RequestDelegate;
    }

    public static RequestDelegate Middleware2(RequestDelegate next)
    {
        async Task RequestDelegate(HttpContext context)
        {
            await context.Response.WriteAsync("World");
            await next(context);
        }

        return RequestDelegate;
    }
}