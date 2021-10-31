using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares.MiddlewareData;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next) { }
        
        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetEntryAssembly()?.GetName().Name?.ToString() ?? "Unknown name";

            VersionData versionData = new VersionData(serviceName, version);

            await context.Response.WriteAsync(versionData.ToString());
            
        }
    }
}