using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using OzonEdu.merchandise_service.Infrastructure.Middlewares.MiddlewareData;

namespace OzonEdu.merchandise_service.Infrastructure.Middlewares
{
    /// <summary> Middleware, отвечающий за логгирование ответов </summary>
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            await LogResponse(context);
            
            /*var originalBody = context.Response.Body;
            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            try
            {
                await _next(context);
                newBody.Seek(0, SeekOrigin.Begin);
                var bodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                if (bodyText.Length > 0)
                    _logger.LogInformation($"Response logged: {bodyText}");
                //Console.WriteLine($"LoggingMiddleware: {bodyText}");
                newBody.Seek(0, SeekOrigin.Begin);
                await newBody.CopyToAsync(originalBody);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response body");
            }
            finally
            {
                
            }*/
        }
        
        /// <summary> Выполняет логгирование ответа </summary>
        /// <param name="context"> Http context </param>
        private async Task LogResponse(HttpContext context)
        {
            try
            {
                if (context.Response.HasStarted && context.Response.Headers.Count > 0)
                {
                    if(string.Equals(context.Request.ContentType ,"application/grpc",StringComparison.OrdinalIgnoreCase))
                    {
                        return;
                    }

                    string path = context.Request.Path;
                    Dictionary<string, string> headerDictionary = new Dictionary<string, string>();
                    foreach (var header in context.Response.Headers)
                    {
                        headerDictionary.Add(header.Key, header.Value);
                    }

                    RouteData routeData = new RouteData(path, headerDictionary);

                    _logger.LogInformation(routeData.ToString());
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log response!");
            }
        }

        
    }
}