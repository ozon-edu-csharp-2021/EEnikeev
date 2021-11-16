using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Routing;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Domain.Contracts;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        
        public EmployeeRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
        
        public IUnitOfWork UnitOfWork { get; }
        
        public Task<int> CreateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee employee, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetWaitingMerchEmployeesAsync(CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
            /*const string sql = @"
                SELECT employees.id, employees.firstname, employees.lastname
                FROM employees";
            
            var connection = await _dbConnectionFactory.CreateConnection(token);

            var result = await connection.QueryAsync<DtoModels.Employee>(sql);

            return Task.FromResult(null);*/
        }
    }
}