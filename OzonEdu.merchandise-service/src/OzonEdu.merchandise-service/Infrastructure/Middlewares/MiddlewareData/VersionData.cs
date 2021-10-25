namespace OzonEdu.merchandise_service.Infrastructure.Middlewares.MiddlewareData
{
    /// <summary> Данные о версии </summary>
    public class VersionData
    {
        public VersionData(string serviceName, string version)
        {
            ServiceName = serviceName;
            Version = version;
        }

        /// <summary> Имя сервиса </summary>
        public string ServiceName { get; set; }
        
        /// <summary> Текущая версия </summary>
        public string Version { get; set; }

        public override string ToString()
        {
            return $"version: {Version}, serviceName: {ServiceName}";
        }
    }
}