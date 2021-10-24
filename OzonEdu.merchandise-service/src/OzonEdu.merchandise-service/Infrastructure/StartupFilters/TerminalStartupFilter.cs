using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.merchandise_service.Infrastructure.Middlewares;

namespace OzonEdu.merchandise_service.Infrastructure.StartupFilters
{
    public class TerminalStartupFilter: IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", builder => builder.UseMiddleware<VersionMiddleware>());
                app.UseMiddleware<RequestLoggingMiddleware>();
                app.UseMiddleware<ResponseLoggingMiddleware>();
                // лучше сделать 2 отдельных middleware или два общих?
                //app.Map("/live", builder => builder.UseMiddleware<LiveMiddleware>());
                //app.Map("/ready", builder => builder.UseMiddleware<ReadyMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<Ok200Middleware>());
                app.Map("/ready", builder => builder.UseMiddleware<Ok200Middleware>());
                next(app);
            };
        }
    }
}