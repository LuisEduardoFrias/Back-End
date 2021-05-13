using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/affiliate")]
    [ApiController]
    public class AffiliateAdoController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.ado.get.affiliates+json" })]
        public async Task<ActionResult> Show()
        {
            //var showAffiliatesDto = await AffiliateAdo.Show();

            //if (showAffiliatesDto.Count != 0)
            //    if (showAffiliatesDto[0].IsError == true)
            //        throw new System.Exception("an error occurred while getting the Affiliates collection.");

            //return Ok(showAffiliatesDto);
            return NoContent();
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.ado.get.seach.affiliate+json" })]
        public async Task<ActionResult<ShowAffiliateDto>> Show([FromQuery] string identificationCard)
        {
            //if (identificationCard == null)
            //    return NotFound(new { error = "identificationCard is null" });

            //var showAffiliateDto = await AffiliateAdo.Search(identificationCard);

            //if (showAffiliateDto.IsError == true)
            //    throw new System.Exception("an error occurred while getting the Affiliate.");

            //if (showAffiliateDto.Id == default)
            //    return NotFound(new { Error = "affiliate not found" });

            //return showAffiliateDto;
            return NoContent();
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.ado.create.affiliate+json" })]
        public async Task<ActionResult> Create([FromBody] CreateAffiliateDto affiliateDto)
        {
            //if (!await AffiliateAdo.Create(affiliateDto))
            //    throw new System.Exception("an error occurred while creating the Affiliate");

            return NoContent();
        }


        [HttpPatch]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.ado.update.amonunt.affiliate+json" })]
        public async Task<ActionResult> Update([FromBody] UpdateAmountAffiliateDto UpdateAmountaffiliateDto)
        {
            //decimal NewAmountConsumed = UpdateAmountaffiliateDto.AmountConsumed + UpdateAmountaffiliateDto.NewAmount;

            //if (!await AffiliateAdo.UpdateAmountAffiliate(UpdateAmountaffiliateDto.IdentificationCard, NewAmountConsumed))
            //    throw new System.Exception("an error occurred while updating the amount consumed from filing");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.ado.update.affiliate+json" })]
        public async Task<ActionResult> Update([FromBody] UpdateAffiliateDto affiliateDto)
        {
            //if (!await AffiliateAdo.Update(affiliateDto))
            //    throw new System.Exception("an error occurred while updating the Affiliate");

            return NoContent();
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.ado.changestatus.affiliate+json" })]
        public async Task<ActionResult> ChangeStatus([FromQuery] string IdentificationCard, [FromQuery] bool status)
        {

            //if (IdentificationCard == null)
            //    return BadRequest(new { error = "identity is null" });

            //if (!await AffiliateAdo.ChangeStatus(IdentificationCard, status))
            //    throw new System.Exception("an error occurred while changing the affiliate status");

            return NoContent();
        }


    }
}
