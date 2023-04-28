var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/test", async appBuilder =>
{
    appBuilder.Use(async (context, next) =>
    {
        context.Response.ContentType = "text/hmtl";
        await context.Response.WriteAsync("1 start<br/>");
        await next.Invoke();
        await context.Response.WriteAsync("1 end<br/>");
    });
    appBuilder.Use(async (context, next) =>
    {
        await context.Response.WriteAsync("2 start<br/>");
        await next.Invoke();
        await context.Response.WriteAsync("2 end<br/>");
    });
    appBuilder.Run(async ctx =>
    {
        await ctx.Response.WriteAsync("hello middleware<br/>");
    });

});

app.Run();

