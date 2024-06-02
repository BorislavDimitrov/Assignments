using DummyProject.StartUp;
using Serilog;
using System.Diagnostics;

namespace DummyProject.StartUp
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestTimingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            Log.Information("Handling request: " + context.Request.Path);

            await _next(context);

            stopwatch.Stop();
            Log.Information($"Finished handling request. Time taken: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}


public static class RequestTimingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestTiming(this IApplicationBuilder builder)
        => builder.UseMiddleware<RequestTimingMiddleware>();
}