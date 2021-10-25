using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OzonEdu.merchandise_service.Infrastructure.Filters;
using OzonEdu.merchandise_service.Infrastructure.Interceptors;
using OzonEdu.merchandise_service.Infrastructure.StartupFilters;
using OzonEdu.merchandise_service.Infrastructure.Swagger;

namespace OzonEdu.merchandise_service.Infrastructure.Extensions
{
    public static class HostBuilderExtensions
    {
        /// <summary> Добавляет необходмую инфраструктуру </summary>
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
                
                services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
                services.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {Title = "OzonEdu.MerchandiseService", Version = "v1"});
                
                    options.CustomSchemaIds(x => x.FullName);

                    var xmlFileName = Assembly.GetEntryAssembly().GetName().Name + ".xml";
                    var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                    options.IncludeXmlComments(xmlFilePath);

                    //options.OperationFilter<HeaderOperationFilter>();
                });
                
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
                services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());
            });
            return builder;
        }
        
        /*public static IHostBuilder AddHttp(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            });
            
            return builder;
        }*/
    }
}