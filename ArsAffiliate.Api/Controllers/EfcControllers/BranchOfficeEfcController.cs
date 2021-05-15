using ArsAffiliate.Domain.Dtos.BranchOffice;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/branchoffice")]
    [ApiController]
    public class BranchOfficeEfcController : BaseController
    {
        public BranchOfficeEfcController(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.branchoffices+json" })]
        public async Task<ActionResult<List<ShowBranchOfficeDto>>> Show()
        {
            return await applicationBranchOffice.ShowAsync();
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.branchoffices+json" })]
        public async Task<ActionResult<List<ShowBranchOfficeDto>>> Show([FromQuery] string filter)
        {
            return await applicationBranchOffice.ShowAsync(filter);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.branchoffices+json" })]
        public async Task<IActionResult> Create([FromBody] CreateBranchOfficeDto branchOfficeDto)
        {
            return await applicationBranchOffice.CreateAsync(branchOfficeDto);
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.branchoffices+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateBranchOfficeDto branchOfficeDto)
        {
            return await applicationBranchOffice.UpdateAsync(branchOfficeDto);
        }


        [HttpPatch("{IdentificationCard, status}")]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.changestatus.affiliate+json" })]
        public async Task<IActionResult> ChangeStatus([FromQuery] int id, [FromQuery] bool status)
        {
            return await applicationBranchOffice.ChangeStatusAsync(id, status);
        }
    }
}
