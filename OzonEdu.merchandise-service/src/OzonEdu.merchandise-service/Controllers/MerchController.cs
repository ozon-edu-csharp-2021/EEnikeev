using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OzonEdu.merchandise_service.HttpModels;
using OzonEdu.merchandise_service.Services.Interfaces;

namespace OzonEdu.merchandise_service.Controllers
{
    [ApiController]
    [Route("v1/api/merch")]
    [Produces("application/json")]
    public class MerchController : ControllerBase
    {
        private readonly IMerchandiseService _merchService;

        public MerchController(IMerchandiseService merchService)
        {
            _merchService = merchService;
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
            var isIssued = await _merchService.GetMerchIsIssuedById(id, token);

            if (isIssued is null)
            {
                return NotFound();
            }

            return Ok(isIssued);
        }
        
        
        
    }
}