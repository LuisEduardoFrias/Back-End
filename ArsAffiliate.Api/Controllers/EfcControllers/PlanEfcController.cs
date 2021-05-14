using ArsAffiliate.Domain.Dtos.Plan;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/plan")]
    [ApiController]
    public class PlanEfcController : BaseController
    {
        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.plans+json" })]
        public async Task<ActionResult<List<ShowPlanDto>>> Show()
        {
            return await applicationPlan.ShowAsync();
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.wherestatustrue.plans+json" })]
        public async Task<ActionResult<List<ShowPlanDto>>> ShowAllWhereStatusTrue()
        {
            return await applicationPlan.ShowWhereStatusTrueAsync();
        }


        [HttpGet("{search}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.search.plan+json" })]
        public async Task<ActionResult<List<ShowPlanDto>>> Search([FromQuery] string filter)
        {
            return await applicationPlan.ShowAsync(filter);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.plan+json" })]
        public async Task<ActionResult> Create([FromBody] CreatePlanDto PlanDto)
        {
            return await applicationPlan.CreateAsync(PlanDto);
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.plan+json" })]
        public async Task<ActionResult> Update([FromBody] UpdatePlanDto PlanDto)
        {
            return await applicationPlan.UpdateAsync(PlanDto);
        }


        [HttpPatch("{identity, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application.vnd.arsaffiliate.efc.changestatus.plan+json" })]
        public async Task<ActionResult> ChangeStatus([FromQuery] int id, [FromQuery] bool status)
        {
            return await applicationPlan.ChangeStatusAsync(id, status);
        }


    }
}
