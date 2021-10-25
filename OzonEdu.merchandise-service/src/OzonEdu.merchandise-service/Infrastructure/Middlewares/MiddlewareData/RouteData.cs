using System.Collections.Generic;
using System.Text;

namespace OzonEdu.merchandise_service.Infrastructure.Middlewares.MiddlewareData
{
    /// <summary> Данные маршрутизации </summary>
    public class RouteData
    {
        /// <summary> Маршрут запроса </summary>
        public string Route { get; }
        
        /// <summary> Заголовки </summary>
        public Dictionary<string, string> Headers { get; init; }

        public RouteData(string route, Dictionary<string, string> headers)
        {
            Route = route;
            Headers = headers;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(200);
            sb.Append($"\nRoute: {Route}\n");
            sb.Append("Headers:\n");
            foreach (var header in Headers)
            {
                sb.Append($"{header.Key}:{header.Value}\n");
            }

            return sb.ToString();
        }
    }
}