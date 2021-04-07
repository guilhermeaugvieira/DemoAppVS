using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace DemoAppVS
{
    public class Middleware
    {
        public readonly RequestDelegate _next;

        public Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("\n\r ------ Antes ------ \n\r");

            await _next(context);

            Console.WriteLine("\n\r ------ Depois ------ \n\r");
        }
    }

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseMiddlewareExtension(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();                   
        }
    }
}
