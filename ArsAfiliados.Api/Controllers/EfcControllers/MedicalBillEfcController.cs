using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Service.RequestHeaderMatchMadiaType;
//

namespace ArsAfiliados.Api.Controllers
{
    [Route("api/medicalbill")]
    [ApiController]
    public class MedicalBillEfcController : BaseController
    {

        [HttpGet]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.medicalbill+json" })]
        public async Task<IActionResult> Show()
        {
            var showMedicalBillsDto = await MedicalBillEfc.Show();

            if (showMedicalBillsDto.Count != 0)
                if (showMedicalBillsDto[0].IsError == true)
                    throw new System.Exception("an error occurred while getting the medical bill collection.");

            return Ok(showMedicalBillsDto);
        }


        [HttpGet("{identificationCard}")]
        [RequestHeaderMatchMadiaType("Accept", new string[] { "application/vnd.arsaffiliate.efc.get.seach.medicalbill+json" })]
        public async Task<IActionResult> Show([FromQuery] string identificationCard)
        {
            if (identificationCard == null)
                return NotFound(new { error = "identificationCard is null" });

            var showMedicalBillDto = await MedicalBillEfc.Search(identificationCard);

            if (showMedicalBillDto.IsError == true)
                throw new System.Exception("an error occurred while getting the medical bill.");

            if (showMedicalBillDto.Id == default)
                return NotFound(new { Error = "affiliate not found" });

            return Ok(showMedicalBillDto);
        }


        [HttpPost]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.create.medicalbill+json" })]
        public async Task<IActionResult> Create([FromBody] CreateMedicalBillDto medicalbillDto)
        {
            if (!await MedicalBillEfc.Create(medicalbillDto))
                throw new System.Exception("an error occurred while creating the medical bill");

            return NoContent();
        }


        [HttpPut]
        [RequestHeaderMatchMadiaType("Content-Type", new string[] { "application/vnd.arsaffiliate.efc.update.medicalbill+json" })]
        public async Task<IActionResult> Update([FromBody] UpdateMedicalBillDto medicalbillDto)
        {
            if (!await MedicalBillEfc.Update(medicalbillDto))
                throw new System.Exception("an error occurred while updating the medical bill");

            return NoContent();
        }

    }
}
