public class LoginVerification(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;
    public async Task InvokeAsync(HttpContext context)
    {
        string? Email = context.Request.Query["email"];
        string? Password = context.Request.Query["password"];
        string? EmailToMatch = "admin@example.com";
        string? PasswordToMatch = "admin1234";
        if (Email == null && Password == null)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync(@"Invalid input for 'email' Invalid input for 'password");
            return;
        }
        if (Email != EmailToMatch || PasswordToMatch != Password)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("Invalid login");
            return;
        }
        await _next(context);
    }

}
public static class LoginVerificationExtension
{
    public static IApplicationBuilder UseLoginVerification(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LoginVerification>();
    }
}