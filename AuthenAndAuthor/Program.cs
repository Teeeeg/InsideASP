using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDataProtection();
var app = builder.Build();

app.MapGet("/username", (HttpContext ctx, IDataProtectionProvider dp) =>
{
    var dataProtector = dp.CreateProtector("auth-cookie");
    var authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
    var protectedPayload = authCookie.Split("=").Last();
    var payload = dataProtector.Unprotect(protectedPayload);
    var parts = payload.Split(":");

    return parts.Last();
});


app.MapGet("/login", (HttpContext ctx, IDataProtectionProvider dp) =>
{
    var dataProtector = dp.CreateProtector("auth-cookie");
    ctx.Response.Headers.SetCookie = $"auth={dataProtector.Protect("usr:andrew")}";
    return "ok";
});


app.Run();
