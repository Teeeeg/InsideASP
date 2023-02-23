namespace Pipeline.Middleware;

public class StringContentMiddleware1
{
    private readonly RequestDelegate _next;
    private readonly string _content;
    private readonly bool _forwardToNext;

    public StringContentMiddleware1(RequestDelegate next, string content, bool forwardToNext = true)
    {
        _next = next;
        _content = content;
        _forwardToNext = forwardToNext;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.WriteAsync(_content);
        if (_forwardToNext)
        {
            await _next(context);
        }
    }
}