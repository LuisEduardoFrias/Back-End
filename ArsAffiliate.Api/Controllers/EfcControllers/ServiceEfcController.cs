using ArsAffiliate.Domain.Dtos.Service;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/service")]
    [ApiController]
    public class ServiceEfcController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.service+json" })]
        public async Task<IActionResult> Show()
        {
        //    var showServiceaDto = await ServiceEfc.Show();

        //    if (showServiceaDto.Count != 0)
        //        if (showServiceaDto[0].IsError == true)
        //            throw new System.Exception("an error occurred while getting the Servicea collection.");

        //    return Ok(showServiceaDto);
            return NoContent();
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.service+json" })]
        public async Task<IActionResult> Show([FromQuery] string identificationCard)
        {
        //if (identificationCard == null)
        //    return NotFound(new { error = "identificationCard is null" });

        //var showServiceDto = await ServiceEfc.Search(identificationCard);

        //if (showServiceDto.IsError == true)
        //    throw new System.Exception("an error occurred while getting the Affiliate.");

        //if (showServiceDto.Id == default)
        //    return NotFound(new { Error = "service not found" });

        //return Ok(showServiceDto);
        return NoContent();
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.service+json" })]
        public async Task<IActionResult> Create([FromBody] CreateServiceDto affiliateDto)
        {
            //if (!await ServiceEfc.Create(affiliateDto))
            //    throw new System.Exception("an error occurred while creating the service");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.service+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateServiceDto serviceDto)
        {
            //if (!await ServiceEfc.Update(serviceDto))
            //    throw new System.Exception("an error occurred while updating the service");

            return NoContent();
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.changestatus.service+json" })]
        public async Task<IActionResult> ChangeStatus([FromQuery] string IdentificationCard, [FromQuery] bool status)
        {

            //if (IdentificationCard == null)
            //    return BadRequest(new { error = "identity is null" });

            //if (!await ServiceEfc.ChangeStatus(IdentificationCard, status))
            //    throw new System.Exception("an error occurred while changing the service status");

            return NoContent();
        }


    }
}
