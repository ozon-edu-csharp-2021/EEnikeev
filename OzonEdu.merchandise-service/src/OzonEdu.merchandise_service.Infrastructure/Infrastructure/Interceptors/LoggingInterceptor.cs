using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace OzonEdu.merchandise_service.Infrastructure.Interceptors
{
    /// <summary> interceptor для логгирования </summary>
    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation("\nInterceptor request log: \n" + requestJson);
            
            var response = base.UnaryServerHandler(request, context, continuation);

            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation("\nInterceptor response log: \n" + responseJson);
            
            return response;
        }

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context, AsyncServerStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            _logger.LogInformation("Streaming has been called");
            return base.AsyncServerStreamingCall(request, context, continuation);
        }
    }

    
} 