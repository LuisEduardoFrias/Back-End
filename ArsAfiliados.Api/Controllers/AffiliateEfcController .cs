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
    public class AffiliateEfcController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.affiliates+json" })]
        public async Task<IActionResult> Show()
        {
            var showAffiliatesDto = await AffiliateEfc.Show();

            if (showAffiliatesDto.Count != 0)
                if (showAffiliatesDto[0].IsError == true)
                    throw new System.Exception("an error occurred while getting the Affiliates collection.");

            return Ok(showAffiliatesDto);
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.affiliate+json" })]
        public async Task<IActionResult> Show([FromQuery] string identificationCard)
        {
            if (identificationCard == null)
                return NotFound(new { error = "identificationCard is null" });
            
            var showAffiliateDto = await AffiliateEfc.Search(identificationCard);

            if (showAffiliateDto.IsError == true)
                throw new System.Exception("an error occurred while getting the Affiliate.");

            if (showAffiliateDto.Id == default)
                return NotFound(new { Error = "affiliate not found" });

            return Ok(showAffiliateDto);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.affiliate+json" })]
        public async Task<IActionResult> Create([FromBody] CreateAffiliateDto affiliateDto)
        {
            if (!await AffiliateEfc.Create(affiliateDto))
                throw new System.Exception("an error occurred while creating the Affiliate");

            return NoContent();
        }


        [HttpPatch]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.amonunt.affiliate+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateAmountAffiliateDto UpdateAmountaffiliateDto)
        {
            decimal NewAmountConsumed = UpdateAmountaffiliateDto.AmountConsumed + UpdateAmountaffiliateDto.NewAmount;

            if (!await AffiliateEfc.UpdateAmountAffiliate(UpdateAmountaffiliateDto.IdentificationCard, NewAmountConsumed))
                throw new System.Exception("an error occurred while updating the amount consumed from filing");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.affiliate+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateAffiliateDto affiliateDto)
        {
            if (!await AffiliateEfc.Update(affiliateDto))
                throw new System.Exception("an error occurred while updating the Affiliate");

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
