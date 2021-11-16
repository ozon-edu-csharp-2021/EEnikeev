using System.Threading.Tasks;
using Grpc.Core;
using MediatR;
using OzonEdu.MerchandiseService.Grpc;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.GrpcServices
{
    public class MerchApiGrpcService : MerchServiceGrpc.MerchServiceGrpcBase
    {
        //private readonly IMerchandiseService _merchandiseService;
        private readonly IMediator _mediator;
        
        public MerchApiGrpcService(IMediator mediator)
        {
            //_merchandiseService = merchandiseService;
            _mediator = mediator;
        }

        public override async Task<GiveMerchItemResponse> GiveMerchToEmployee(
            GiveMerchItemRequest request,
            ServerCallContext context)
        {
            var command = new GiveMerchItemCommand(request.EmployeeId, request.MerchId, request.ClothingSizeId);
            await _mediator.Send(command);

            return new GiveMerchItemResponse();
        }
        
        public override async Task<GetMerchIsIssuedResponse> GetMerchIsIssued(
            GetMerchItemIsGivenRequest request,
            ServerCallContext context)
        {
            var command = new GetMerchIsIssuedCommand(request.EmployeeId, request.MerchId);
            var result = await _mediator.Send(command);
            
            return new GetMerchIsIssuedResponse()
            {
                IsIssued = result
            };
        }
    }
}