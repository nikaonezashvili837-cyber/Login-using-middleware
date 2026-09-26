var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    string? Email = context.Request.Query["email"];
    string? Password = context.Request.Query["email"];
    string? EmailToMatch =  "admin@example.com";
    string? PasswordToMatch = "admin1234";
    if(Email != EmailToMatch || PasswordToMatch == Password)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Invalid login");
        return;
    }
    await next(context);
});
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Succesesful login");
});


app.Run();
