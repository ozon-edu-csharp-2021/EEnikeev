using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OzonEdu.merchandise_service.Infrastructure.Middlewares.MiddlewareData;

namespace OzonEdu.merchandise_service.Infrastructure.Middlewares
{
    /// <summary> Middleware, отвечающий за логгирование запросов </summary>
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            LogRequest(context);
            await _next(context);
        }

        private void LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.Headers.Count > 0)
                {
                    
                    if(string.Equals(context.Request.ContentType ,
                        "application/grpc",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }
                    context.Request.EnableBuffering();

                    string path = context.Request.Path;
                    Dictionary<string, string> headerDictionary = new Dictionary<string, string>();
                    foreach (var header in context.Request.Headers)
                    {
                        headerDictionary.Add(header.Key, header.Value);
                    }

                    RouteData routeData = new RouteData(path, headerDictionary);

                    _logger.LogInformation(routeData.ToString());

                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request!");
            }
        }
    }
}