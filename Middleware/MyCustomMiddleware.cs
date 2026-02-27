namespace MiddleWareDeepDive.Middleware
{
    public class MyCustomMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("Custom Middleware 1 before running next" + Environment.NewLine);

            await next(context); 

            await context.Response.WriteAsync("Custom Middleware 1 after running next" + Environment.NewLine);
        }
    }
}
