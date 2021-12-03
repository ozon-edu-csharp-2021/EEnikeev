using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OpenTracing;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares.MiddlewareData
{
    public class SpanMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITracer _tracer;

        public SpanMiddleware(RequestDelegate next, ITracer tracer)
        {
            _next = next;
            _tracer = tracer;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            using var span = _tracer.BuildSpan("RequestMiddleware.InvokeAsync").StartActive();
            await _next(context);
        }
    }
}