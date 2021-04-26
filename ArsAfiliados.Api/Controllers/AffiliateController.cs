using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Service.RequestHeaderMatchMadiaType;
//

namespace ArsAfiliados.Api.Controllers
{
    [Route("api/affiliate")]
    [ApiController]
    public class AffiliateController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.get.affiliates+json" })]
        public async Task<IActionResult> Show()
        {
            var showAffiliatesDto = await Affiliate.Show();

            if (showAffiliatesDto.Count != 0)
                if (showAffiliatesDto[0].IsError == true)
                    throw new System.Exception("an error occurred while getting the Affiliates collection.");

            return Ok(showAffiliatesDto);
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.get.seach.affiliate+json" })]
        public async Task<IActionResult> Show(string identificationCard)
        {
            if (identificationCard == null)
                return NotFound(new { error = "identificationCard is null" });
            
            var showAffiliateDto = await Affiliate.Search(identificationCard);

            if (showAffiliateDto.IsError == true)
                throw new System.Exception("an error occurred while getting the Affiliate.");

            if (showAffiliateDto.Id == default)
                return NotFound(new { Error = "affiliate not found" });

            return Ok(showAffiliateDto);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.create.affiliate+json" })]
        public async Task<IActionResult> Create([FromBody] CreateAffiliateDto affiliateDto)
        {
            if (!await Affiliate.Create(affiliateDto))
                throw new System.Exception("an error occurred while creating the Affiliate");

            return NoContent();
        }


        [HttpPatch]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.update.amonunt.affiliate+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateAmountAffiliateDto UpdateAmountaffiliateDto)
        {
            if (!await Affiliate.UpdateAmountAffiliate(UpdateAmountaffiliateDto))
                throw new System.Exception("an error occurred while updating the amount consumed from filing");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.update.affiliate+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateAffiliateDto affiliateDto)
        {
            if (!await Affiliate.Update(affiliateDto))
                throw new System.Exception("an error occurred while updating the Affiliate");

            return NoContent();
        }


        [HttpPatch]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.changestatus.affiliate+json" })]
        public async Task<IActionResult> ChangeStatus(string IdentificationCard, bool status)
        {

            if (IdentificationCard == null)
                return BadRequest(new { error = "identity is null" });

            if (!await Affiliate.ChangeStatus(IdentificationCard, status))
                throw new System.Exception("an error occurred while changing the affiliate status");

            return NoContent();
        }


    }
}
