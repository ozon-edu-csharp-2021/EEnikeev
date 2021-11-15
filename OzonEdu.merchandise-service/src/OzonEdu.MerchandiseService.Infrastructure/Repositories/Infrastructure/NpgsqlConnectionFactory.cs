using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Npgsql;
using OzonEdu.MerchandiseService.Infrastructure.Configuration;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure
{
    public class NpgsqlConnectionFactory : IDbConnectionFactory<NpgsqlConnection>
    {
        private readonly string _connectionString;
        private NpgsqlConnection _connection;
        
        public NpgsqlConnectionFactory(IOptions<DatabaseConnectionOptions> options)
        {
            _connectionString = options.Value.ConnectionString;
        }
        
        public async Task<NpgsqlConnection> CreateConnection(CancellationToken token)
        {
            if (_connection != null) return _connection;

            _connection = new NpgsqlConnection(_connectionString);
            await _connection.OpenAsync(token);
            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}