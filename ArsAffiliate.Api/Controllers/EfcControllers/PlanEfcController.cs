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
            //var showPlansDto = await PlanEfc.Show();

            //if (showPlansDto.Count != 0)
            //    if (showPlansDto[0].IsError == true)
            //        throw new System.Exception("an error occurred while getting the Plans collection.");

            //return Ok(showPlansDto);
            return NoContent();
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.wherestatustrue.plans+json" })]
        public async Task<ActionResult<List<ShowPlanDto>>> ShowAllWhereStatusTrue()
        {
            //var showPlansDto = await PlanEfc.ShowAllWhereStatusTrue();

            //if (showPlansDto.Count != 0)
            //    if (showPlansDto[0].IsError == true)
            //        throw new System.Exception("an error occurred while getting the Plans collection.");

            //return Ok(showPlansDto);
            return NoContent();
        }


        [HttpGet("{search}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.search.plan+json" })]
        public async Task<ActionResult<ShowPlanDto>> Search([FromQuery] string search)
        {
            //if (search == null)
            //    return BadRequest(new { error = "search is null" });

            //var showPlanDto = await PlanEfc.Search(search);

            //if (showPlanDto.IsError == true)
            //    throw new System.Exception("an error occurred while getting the Plan.");

            //if (showPlanDto.Id == default)
            //    return NotFound();

            //return showPlanDto;
            return NoContent();
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.plan+json" })]
        public async Task<ActionResult> Create([FromBody] CreatePlanDto PlanDto)
        {
            //if (!await PlanEfc.Create(PlanDto))
            //    throw new System.Exception("an error occurred while creating the Plan");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.plan+json" })]
        public async Task<ActionResult> Update([FromBody] UpdatePlanDto PlanDto)
        {
            //if (!await PlanEfc.Update(PlanDto))
            //    throw new System.Exception("an error occurred while updating the Plan");

            return NoContent();
        }


        [HttpPatch("{identity, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application.vnd.arsaffiliate.efc.changestatus.plan+json" })]
        public async Task<ActionResult> ChangeStatus([FromQuery] string identity, [FromQuery] bool status)
        {
            //if (identity == null)
            //    return BadRequest(new { error = "identity is null" });

            //if (!await PlanEfc.ChangeStatus(identity, status))
            //    throw new System.Exception("an error occurred while changing the affiliate status");

            return NoContent();
        }


    }
}
