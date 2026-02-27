var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// The .Use() method is one way of creating a middleware.
// The Use() accepts a delegate and provides 2 parameters to the executing middleware
// As the follwoing code is only declaring middleware, it will not run
// when the application starts, it will run when the running server recieves a request.

// Terminal middleware, just dont called the next() request delegate, this however 
// mandates specifying type of ReqestDelegate provided to the delegate/anonymous fuction
app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 1 before running next" + Environment.NewLine);

    await next(context); // This will send the context to the second middleware rather than executing the next line

    await context.Response.WriteAsync("Middleware 1 after running next" + Environment.NewLine);
    // Response will be sent back to the kestral server
});

// The Map() expects a path and provides a application builder interface
// instance to build a seperate middleware pipeline based on the path.
// This will brach off after the first middleware.
app.Map("/employees", (app2) =>
{
    app2.Use(async (HttpContext context, RequestDelegate next) =>
    {
        await context.Response.WriteAsync("Middleware 5 before running next" + Environment.NewLine);

        await next(context); // This will send the context to the second middleware rather than executing the next line

        await context.Response.WriteAsync("Middleware 5 after running next" + Environment.NewLine);
        // Response will be sent back to the kestral server
    });
    app2.Use(async (HttpContext context, RequestDelegate next) =>
    {
        await context.Response.WriteAsync("Middleware 6 before running next" + Environment.NewLine);

        await next(context); // This will send the context to the second middleware rather than executing the next line

        await context.Response.WriteAsync("Middleware 6 after running next" + Environment.NewLine);
        // Response will be sent back to the kestral server
    });
});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 2 before running next" + Environment.NewLine);

    await next(context);

    await context.Response.WriteAsync("Middleware 3 after running next" + Environment.NewLine);


});

app.Use(async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 3 before running next" + Environment.NewLine);

    await next(context); // There is no middleware next in the pipeline so the following line will execute

    await context.Response.WriteAsync("Middleware 3 after running next" + Environment.NewLine);
    // Execution will go back to after the next() function call of the second/callingN middleware
});

app.Run();
