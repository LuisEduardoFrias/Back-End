using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Service.RequestHeaderMatchMadiaType;
//

namespace ArsAfiliados.Api.Controllers
{
    [Route("api/plan")]
    [ApiController]
    public class PlanAdoController : BaseController
    {
        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.ado.get.plans+json" })]
        public async Task<ActionResult<List<ShowPlanDto>>> Show()
        {
            var showPlansDto = await PlanAdo.Show();

            if (showPlansDto.Count != 0)
                if (showPlansDto[0].IsError == true)
                    throw new System.Exception("an error occurred while getting the Plans collection.");

            return Ok(showPlansDto);
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.ado.get.wherestatustrue.plans+json" })]
        public async Task<ActionResult<List<ShowPlanDto>>> ShowAllWhereStatusTrue()
        {
            var showPlansDto = await PlanAdo.ShowAllWhereStatusTrue();

            if (showPlansDto.Count != 0)
                if (showPlansDto[0].IsError == true)
                    throw new System.Exception("an error occurred while getting the Plans collection.");

            return Ok(showPlansDto);
        }
        

        [HttpGet("{search}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.ado.get.search.plan+json" })]
        public async Task<ActionResult<ShowPlanDto>> Search([FromQuery] string search)
        {
            if (search == null)
                return BadRequest(new { error = "search is null"});

            var showPlanDto = await PlanAdo.Search(search);

            if (showPlanDto.IsError == true)
                throw new System.Exception("an error occurred while getting the Plan.");

            if (showPlanDto.Id == default)
                return NotFound();

            return showPlanDto;
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.ado.create.plan+json" })]
        public async Task<ActionResult> Create([FromBody] CreatePlanDto PlanDto)
        {
            if (!await PlanAdo.Create(PlanDto))
                throw new System.Exception("an error occurred while creating the Plan");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.ado.update.plan+json" })]
        public async Task<ActionResult> Update([FromBody] UpdatePlanDto PlanDto)
        {
            if (!await PlanAdo.Update(PlanDto))
                throw new System.Exception("an error occurred while updating the Plan");

            return NoContent();
        }


        [HttpPatch("{identity, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application.vnd.arsaffiliate.ado.changestatus.plan+json" })]
        public async Task<ActionResult> ChangeStatus([FromQuery] string identity, [FromQuery] bool status)
        {
            if (identity == null)
                return BadRequest(new { error = "identity is null" }) ;

            if (!await PlanAdo.ChangeStatus(identity, status))
                throw new System.Exception("an error occurred while changing the affiliate status");

            return NoContent();
        }


    }
}
