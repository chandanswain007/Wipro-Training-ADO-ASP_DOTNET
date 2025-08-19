// Program.cs

using MiddlewareApp.Middleware; // Add this using directive for our custom middleware

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Configure the HTTP request pipeline.

// 1. Custom Error Handling Middleware
// This will catch unhandled exceptions and redirect to a custom error page.
app.UseExceptionHandler("/error");
app.UseHsts();

// 2. Enforce HTTPS
// Redirects all HTTP requests to HTTPS.
app.UseHttpsRedirection();

// 3. Custom Request Logging Middleware
// Our custom middleware to log request and response details.
app.UseMiddleware<RequestLoggingMiddleware>();

// 4. Content Security Policy (CSP) Header
// This middleware adds a security header to prevent XSS attacks.
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'");
    await next();
});

// 5. Static Files Middleware
// This enables the application to serve static files from the wwwroot folder.
app.UseStaticFiles();

// Define a minimal API endpoint for the custom error page.
app.MapGet("/error", () => Results.Problem("An unexpected error occurred.", statusCode: 500));

// Define a root endpoint for basic testing.
app.MapGet("/", () => "Hello World! Navigate to /index.html to see the static file.");

app.Run();