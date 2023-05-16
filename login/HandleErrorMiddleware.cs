using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyShop
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HandleErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public HandleErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandleErrorMiddlewareExtensions
    {
        public static IApplicationBuilder UseHandleErrorMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandleErrorMiddleware>();
        }
    }
}
