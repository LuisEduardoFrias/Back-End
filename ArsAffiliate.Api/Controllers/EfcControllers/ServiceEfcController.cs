using ArsAffiliate.Domain.Dtos.Service;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceEfcController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.service+json" })]
        public async Task<ActionResult<List<ShowServiceDto>>> Show()
        {
            return await applicationService.ShowAsync();
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.service+json" })]
        public async Task<ActionResult<List<ShowServiceDto>>> Show([FromQuery] string filter)
        {
            return await applicationService.ShowAsync(filter);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.service+json" })]
        public async Task<IActionResult> Create([FromBody] CreateServiceDto affiliateDto)
        {
            return await applicationService.CreateAsync(affiliateDto);
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.service+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateServiceDto serviceDto)
        {
            return await applicationService.UpdateAsync(serviceDto);
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.changestatus.service+json" })]
        public async Task<IActionResult> ChangeStatus([FromQuery] int id, [FromQuery] bool status)
        {
            return await applicationService.ChangeStatusAsync(id, status);
        }
    }
}
