using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using OzonEdu.merchandise_service.Grpc;
using OzonEdu.merchandise_service.Services.Interfaces;

namespace OzonEdu.merchandise_service.GrpcServices
{
    /// <summary> Grpc мерч сервис </summary>
    public class MerchApiGrpcService : MerchServiceGrpc.MerchServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchApiGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        /// <summary> Возвращает мерч по идентификатору </summary>
        public override async Task<GetMerchItemByIdResponse> GetMerchById(
            GetMerchItemByIdRequest request,
            ServerCallContext context)
        {
            var merchItem = await _merchandiseService.GetMerchById(request.ItemId, context.CancellationToken);
            if (merchItem == null) throw new RpcException(new Status(StatusCode.InvalidArgument, "Запрашиваемый элемент не найден"));
            return new GetMerchItemByIdResponse()
            {
                ItemId = merchItem.Id,
                ItemName = merchItem.Name
            };
        }
        
        /// <summary> Возвращает информацию о выданном менрче по идентификатору </summary>
        public override async Task<GetMerchIsIssuedResponse> GetMerchIsIssuedById(
            GetMerchItemByIdRequest request,
            ServerCallContext context)
        {
            var isIssued = await _merchandiseService.GetMerchIsIssuedById(request.ItemId, context.CancellationToken);
            if (isIssued == null)throw new RpcException(new Status(StatusCode.InvalidArgument, "Запрашиваемый элемент не найден"));
            return new GetMerchIsIssuedResponse()
            {
                IsIssued = isIssued
            };
        }
    }
}