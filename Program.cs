using MiddleWareDeepDive.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Import the custom middleware class and add it as a service
// This is registering the class type in the services collection.
builder.Services.AddTransient<MyCustomMiddleware>();
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

// Use the added middleware at a specfic location in the pipeline
// This looks into the Services collection to find the intended type.
app.UseMiddleware<MyCustomMiddleware>();

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
