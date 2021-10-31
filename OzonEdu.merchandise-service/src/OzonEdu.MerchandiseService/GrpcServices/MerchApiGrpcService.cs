using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchApiGrpcService : MerchServiceGrpc.MerchServiceGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;
        private readonly IMediator _mediator;
        
        public MerchApiGrpcService(IMerchandiseService merchandiseService, IMediator mediator)
        {
            _merchandiseService = merchandiseService;
            _mediator = mediator;
        }

        public override async Task<GetMerchItemByIdResponse> GetMerchById(
            GetMerchItemByIdRequest request,
            ServerCallContext context)
        {
            var merchItem = await _merchandiseService.GetMerchById(request.ItemId, 
                context.CancellationToken);
            if (merchItem == null) throw new RpcException(new Status(StatusCode.InvalidArgument,
                "Запрашиваемый элемент не найден"));
            return new GetMerchItemByIdResponse()
            {
                ItemId = merchItem.Id,
                ItemName = merchItem.Name
            };
        }
        
        public override async Task<GetMerchIsIssuedResponse> GetMerchIsIssuedById(
            GetMerchItemByIdRequest request,
            ServerCallContext context)
        {
            var isIssued = await _merchandiseService.GetMerchIsIssuedById(request.ItemId, 
                context.CancellationToken);
            if (isIssued == null)throw new RpcException(new Status(StatusCode.InvalidArgument, 
                "Запрашиваемый элемент не найден"));
            return new GetMerchIsIssuedResponse()
            {
                IsIssued = isIssued
            };
        }
    }
}