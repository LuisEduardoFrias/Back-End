using ArsAffiliate.Domain.Dtos.MedicalBill;
using ArsAffiliate.Service.RequestHeaderMatchMadiaType;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArsAffiliate.Api.Controllers
{
    [Route("api/medicalbill")]
    [ApiController]
    public class MedicalBillEfcController : BaseController
    {

        public MedicalBillEfcController(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }


        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.medicalbill+json" })]
        public async Task<ActionResult<List<ShowMedicalBillDto>>> Show()
        {
            return await applicationMedicalBill.ShowAsync();
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.medicalbill+json" })]
        public async Task<ActionResult<List<ShowMedicalBillDto>>> Show([FromQuery] string filter)
        {
            return await applicationMedicalBill.ShowAsync(filter);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.medicalbill+json" })]
        public async Task<IActionResult> Create([FromBody] CreateMedicalBillDto medicalbillDto)
        {
            return await applicationMedicalBill.CreateAsync(medicalbillDto);
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.medicalbill+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateMedicalBillDto medicalbillDto)
        {
            return await applicationMedicalBill.UpdateAsync(medicalbillDto);
        }
    }
}
