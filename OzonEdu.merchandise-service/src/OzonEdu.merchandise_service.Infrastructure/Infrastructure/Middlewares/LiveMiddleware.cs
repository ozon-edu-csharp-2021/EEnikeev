using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.merchandise_service.Infrastructure.Middlewares
{
    public class LiveMiddleware
    {
        private readonly RequestDelegate _next;
        
        public LiveMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            await Task.FromResult(context.Response.StatusCode = 200);
            await context.Response.WriteAsync("");
            //await _next(context);
        }
    }
}