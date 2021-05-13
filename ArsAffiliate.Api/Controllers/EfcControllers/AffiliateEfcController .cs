using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/affiliate")]
    [ApiController]
    public class AffiliateEfcController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.affiliates+json" })]
        public async Task<ActionResult<List<ShowAffiliateDto>>> Show()
        {
            return await applicationAffiliate.ShowAsync();
        }


        [HttpGet("{filter}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.affiliate+json" })]
        public async Task<ActionResult<List<ShowAffiliateDto>>> Show([FromQuery] string filter)
        {
            return await applicationAffiliate.ShowAsync(filter);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.affiliate+json" })]
        public async Task<ActionResult> Create([FromBody] CreateAffiliateDto affiliateDto)
        {
            return await applicationAffiliate.CreateAsync(affiliateDto);
        }


        [HttpPatch]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.amonunt.affiliate+json" })]
        public async Task<ActionResult> Update([FromBody] UpdateAmountAffiliateDto UpdateAmountaffiliateDto)
        {
            return await applicationAffiliate.UpdateAsync(UpdateAmountaffiliateDto);
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.affiliate+json" })]
        public async Task<ActionResult> Update([FromBody] UpdateAffiliateDto affiliateDto)
        {
            return await applicationAffiliate.UpdateAsync(affiliateDto);
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.changestatus.affiliate+json" })]
        public async Task<IActionResult> ChangeStatus([FromQuery] int id, [FromQuery] bool status)
        {
            return await applicationAffiliate.ChangeStatusAsync(id, status);
        }
    }
}
