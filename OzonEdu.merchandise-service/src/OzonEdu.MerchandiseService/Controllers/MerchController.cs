using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        
        public MerchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary> Выдает мерч сотруднику </summary>

        [HttpPost]
        [Route("GiveMerchToEmployee")]
        public async Task GiveMerchToEmployee(GiveMerchItemRequest request,
            CancellationToken token)
        {
            var command = new GiveMerchItemCommand(request.employeeId, request.merchId, request.sizeId);
            await _mediator.Send(command);

            return;
        }
        
        /// <summary> Вызвращает информацию о том, был ли выдан мерч </summary>
        [HttpPost]
        [Route("GetMerchIsIssued")]
        public async Task<bool> GetMerchIsIssued(GetMerchItemIsGivenRequest request,
            CancellationToken token)
        {
            var command = new GetMerchIsIssuedCommand(request.EmployeeId, request.MerchId);
            var isIssued = await _mediator.Send(command);

            return isIssued;
        }




    }
}