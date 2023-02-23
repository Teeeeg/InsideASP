using Pipeline.Middleware;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseMiddleware<StringContentMiddleware1>("Hello", false);

app.Run();