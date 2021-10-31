using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class ReadyMiddleware
    {
        private readonly RequestDelegate _next;
        
        public ReadyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            await Task.FromResult(context.Response.StatusCode = StatusCodes.Status200OK);
            await context.Response.WriteAsync("");
        }
    }
}