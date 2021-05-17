using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/affiliate")]
    [ApiController]
    public class AffiliateEfcController : BaseController
    {

        public AffiliateEfcController(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.affiliates+json" })]
        public async Task<ActionResult<List<ShowAffiliateDto>>> Show()
        {
            return await applicationAffiliate.ShowAsync();
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.affiliate+json" })]
        public async Task<ActionResult<List<ShowAffiliateDto>>> Show([FromQuery] string filter)
        {
            return await applicationAffiliate.ShowAsync(filter);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.affiliate+json" })]
        public async Task Create([FromBody] CreateAffiliateDto affiliateDto)
        {
            await applicationAffiliate.CreateAsync(affiliateDto);
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.affiliate+json" })]
        public async Task Update([FromBody] UpdateAffiliateDto affiliateDto)
        {
            await applicationAffiliate.UpdateAsync(affiliateDto);
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.changestatus.affiliate+json" })]
        public async Task ChangeStatus([FromQuery] int id, [FromQuery] bool status)
        {
            await applicationAffiliate.ChangeStatusAsync(id, status);
        }
    }
}
