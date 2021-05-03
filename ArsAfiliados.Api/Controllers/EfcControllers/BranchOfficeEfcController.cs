using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Service.RequestHeaderMatchMadiaType;
//

namespace ArsAfiliados.Api.Controllers
{
    [Route("api/branchoffice")]
    [ApiController]
    public class BranchOfficeEfcController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.branchoffices+json" })]
        public async Task<IActionResult> Show()
        {
            var showBranchOfficesDto = await AffiliateEfc.Show();

            if (showBranchOfficesDto.Count != 0)
                if (showBranchOfficesDto[0].IsError == true)
                    throw new System.Exception("an error occurred while getting the branch offices collection.");

            return Ok(showBranchOfficesDto);
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.branchoffices+json" })]
        public async Task<IActionResult> Show([FromQuery] string identificationCard)
        {
            if (identificationCard == null)
                return NotFound(new { error = "identificationCard is null" });

            var showBranchOfficeDto = await AffiliateEfc.Search(identificationCard);

            if (showBranchOfficeDto.IsError == true)
                throw new System.Exception("an error occurred while getting the branch offices.");

            if (showBranchOfficeDto.Id == default)
                return NotFound(new { Error = "affiliate not found" });

            return Ok(showBranchOfficeDto);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.branchoffices+json" })]
        public async Task<IActionResult> Create([FromBody] CreateBranchOfficeDto branchOfficeDto)
        {
            if (!await BranchOfficeEfc.Create(branchOfficeDto))
                throw new System.Exception("an error occurred while creating the branch offices");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.branchoffices+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateBranchOfficeDto branchOfficeDto)
        {
            if (!await BranchOfficeEfc.Update(branchOfficeDto))
                throw new System.Exception("an error occurred while updating the branch offices");

            return NoContent();
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.changestatus.affiliate+json" })]
        public async Task<IActionResult> ChangeStatus([FromQuery] string IdentificationCard, [FromQuery] bool status)
        {

            if (IdentificationCard == null)
                return BadRequest(new { error = "identity is null" });

            if (!await AffiliateEfc.ChangeStatus(IdentificationCard, status))
                throw new System.Exception("an error occurred while changing the affiliate status");

            return NoContent();
        }


    }
}
