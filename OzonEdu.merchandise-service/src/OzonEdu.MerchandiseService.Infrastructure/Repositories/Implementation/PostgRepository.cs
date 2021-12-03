using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.DtoModels;
using OzonEdu.MerchandiseService.Infrastructure.Repositories.Infrastructure.Interfaces;
using EmployeeDomain = OzonEdu.MerchandiseService.Domain.AggregationModels.EmployeeAggregate.Employee;
using MerchPackDomain = OzonEdu.MerchandiseService.Domain.AggregationModels.MerchPackAggregate.MerchPack;

namespace OzonEdu.MerchandiseService.Infrastructure.Repositories.Implementation
{
    public class PostgRepository : IRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private const int Timeout = 5;
        
        public PostgRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
       
        public async Task<bool> GetMerchIsGivenAsync(GetMerchIsIssuedCommand request, CancellationToken token)
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

        public async Task<bool> GiveMerchAsync(GiveMerchItemCommand request, CancellationToken token)
        {
            //todo убрать логику из репозитория
            
            // проверяем, выдавался ли мерч сотруднику
            var merchPackOrder = await this.GetMerchPackOrder(request, token);
            
            // если мерч уже выдавался, проверяем, можно ли выдать снова
            if (merchPackOrder != null && merchPackOrder.IsGiven)
            {
                // если мерчпак уже выдан, проверяем дату
                var years = EmployeeDateTime.GetYearsBetween(merchPackOrder.GivingDate, DateTime.Now);
                if (years < EmployeeDomain.MinYearsBeforeNextIssue)
                {
                    // если прошло меньше года, то не выдаем мерч
                    return false;
                }

            }
            
            // данные о заказе
            var newMerchPackOrder = new
            {
                EmployeeId = (long)request.EmployeeId,
                MerchPackId = request.MerchId,
                ClothingSizeId = request.SizeId,
                IsGiven = true,
                GivingDate = DateTime.Now
            };

            string sql;

            if (merchPackOrder == null)
            {
                // добавляем в таблицу
                sql = @"
                    INSERT INTO merch_pack_orders
                    (employee_id, clothing_size_id, merch_pack_id, is_given, giving_date)
                    VALUES
                    (@EmployeeId, @ClothingSizeId, @MerchPackId, @IsGiven, @GivingDate);";
            }
            else
            {
                // изменяем таблицу
                sql = @"
                    UPDATE merch_pack_orders
                    SET
                    clothing_size_id = @ClothingSizeId,
                    is_given = @IsGiven,
                    giving_date = @GivingDate
                    WHERE employee_id = @EmployeeId
                    AND merch_pack_id = @MerchPackId";
            }
            
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: newMerchPackOrder,
                commandTimeout: Timeout,
                cancellationToken: token);

            var connection = await _dbConnectionFactory.CreateConnection(token);
            
            await connection.QueryAsync(commandDefinition);

            return true;
        }

        #region Private


        async Task<MerchPackOrder> GetMerchPackOrder(GiveMerchItemCommand request, CancellationToken token)
        {
            string sql = @"
                SELECT *
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

            var result = await connection.QueryAsync<MerchPackOrder>(commandDefinition);
            
            return result.FirstOrDefault();
        }

        async Task<MerchPack> GetMerchPackById(int merchPackId, CancellationToken token)
        {
            string sql = 
                @"
                SELECT *
                FROM merch_pack_items
                WHERE merch_pack_items.pack_id = @MerchPackId;
                ";
            throw new NotImplementedException();
        }

        async Task<MerchItem> GetMerchItemById(int merchItemId, CancellationToken token)
        {
            throw new NotImplementedException();
        }
        
            

        #endregion
    }
}