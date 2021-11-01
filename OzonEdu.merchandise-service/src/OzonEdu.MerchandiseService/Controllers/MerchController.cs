using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.MerchandiseService.HttpModels;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GetMerchIsIssued;
using OzonEdu.MerchandiseService.Infrastructure.Commands.GiveOutMerchItem;
using OzonEdu.MerchandiseService.Services.Interfaces;

namespace OzonEdu.MerchandiseService.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchandiseService _merchService;
        private readonly IMediator _mediator;
        public MerchController(IMerchandiseService merchService, IMediator mediator)
        {
            _merchService = merchService;
            _mediator = mediator;
        }

        /// <summary> Возвращает мерч по указанному идентификатору</summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("GetMerch/{id:long}")]
        public async Task<ActionResult<MerchItemResponse>> GetMerchById(long id, CancellationToken token)
        {
            var merchItem = await _merchService.GetMerchById(id, token);

            if (merchItem is null)
            {
                return NotFound();
            }

            var response = new MerchItemResponse()
            {
                Id = merchItem.Id,
                Name = merchItem.Name
            };

            return Ok(response);

        }
        
        /// <summary> Возвращает информацию о выдаче мерча с указанным Id  </summary>
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [HttpGet]
        [Route("GetMerchIsIssued/{id:long}")]
        public async Task<ActionResult<MerchItemResponse>> GetMerchIsIssuedById(long id, CancellationToken token)
        {
            var command = new GetMerchIsIssuedCommand((int)id, (int)id);

            var isIssued = await _mediator.Send(command);
            
            /*var isIssued = await _merchService.GetMerchIsIssuedById(id, token);

            if (isIssued is null)
            {
                return NotFound();
            }*/

            return Ok(isIssued);
        }
        
        
        
    }
}