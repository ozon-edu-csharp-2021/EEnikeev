using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.merchandise_service.Infrastructure.Middlewares
{
    /// <summary> Трминальный Middleware, возвращающий код 200 </summary>
    public class Ok200Middleware
    {
        private readonly RequestDelegate _next;
        
        public Ok200Middleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            await Task.FromResult(context.Response.StatusCode = 200);
            //await _next(context);
        }
    }
}