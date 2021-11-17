using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class PostgRepository : IRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;

        public PostgRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        private const int Timeout = 5;

        public async Task<bool> GetMerchIsGiven(GetMerchIsIssuedCommand request, CancellationToken token)
        {
            string sql = @"
                SELECT merch_pack_orders.is_given
                FROM merch_pack_orders
                WHERE merch_pack_orders.employee_id = @EmployeeId
                AND merch_pack_orders.merch_pack_id = @MerchPackId;
                        ";

            var parameters = new
            {
                EmployeeId = request.EmployeeId,
                MerchPackId = request.MerchId
            };

            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: token);

            var connection = await _dbConnectionFactory.CreateConnection(token);

            var result = await connection.QueryAsync<bool>(commandDefinition);
            
            var enumerable = result as bool[] ?? result.ToArray();
            if (!enumerable.Any()) return false;
            else
                return enumerable.First();

        }

        public async Task GiveMerch(GiveMerchItemCommand request, CancellationToken token)
        {
            
        }
    }
}