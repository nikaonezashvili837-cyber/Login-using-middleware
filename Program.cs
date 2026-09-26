var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseLoginVerification();
app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Succesesful login");
});


app.Run();
