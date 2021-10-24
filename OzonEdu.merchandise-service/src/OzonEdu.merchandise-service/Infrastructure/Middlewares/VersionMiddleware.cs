using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OzonEdu.merchandise_service.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        private readonly RequestDelegate _next;
        
        public VersionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name?.ToString() ?? "Unknown name";
            
            await context.Response.WriteAsync($"version: {version}, serviceName: {serviceName}");
            
            //await _next(context);
        }
    }
}