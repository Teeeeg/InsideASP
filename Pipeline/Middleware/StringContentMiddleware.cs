namespace Pipeline.Middleware;

public class StringContentMiddleware: IMiddleware
{
    private readonly string _content;

    public StringContentMiddleware(string content)
    {
        _content = content;
    }

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        return context.Response.WriteAsync(_content);
    }
}