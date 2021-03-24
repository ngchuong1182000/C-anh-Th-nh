
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;

public class MyMiddleware
{
    private readonly RequestDelegate _next;

    public MyMiddleware(RequestDelegate next, ILoggerFactory logFactory)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var sw = new Stopwatch();
        sw.Start();
        string url = httpContext.Request.Path;
        if (url == "/User/Index")
        {
            var name = httpContext.Request.Query["s"];
            if (!String.IsNullOrWhiteSpace(name))
            {
                httpContext.Request.Headers.Add("name", name);
                Thread.Sleep(2000);
                sw.Stop();
            }
            await httpContext.Response.WriteAsync($"<h1> {name} </h1><h2>{sw.Elapsed}</h2>");
            return;
        }
        await _next(httpContext);
    }
}

public static class MyMiddlewareExtensions
{
    public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MyMiddleware>();
    }
}