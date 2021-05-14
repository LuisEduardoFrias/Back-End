using ArsAffiliate.Domain.Dtos.MedicalBill;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Application.EfcApplications
{
    public class MedicalBillEfcApplication : BaseApplicationController
    {
        #region Singletom

        public static MedicalBillEfcApplication Instantice { get; set; }

        public static MedicalBillEfcApplication GetInstance(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new MedicalBillEfcApplication(context, mapper);

            return Instantice;
        }

        #endregion

        private MedicalBillEfcApplication(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ActionResult<List<ShowMedicalBillDto>>> ShowAsync(string filter = null)
        {
            IQueryable<MedicalBill> query = MedicalBillEfc.Show();

            if (filter == null)
                return _mapper.Map<List<ShowMedicalBillDto>>(await query.ToListAsync());

            return _mapper.Map<List<ShowMedicalBillDto>>(await query
                .Where(x => 
                x.RegistrationDate.ToString("dd/MM/yyyy").Contains(filter) || 
                x.Services.Where(x =>
                x.BranchOffice.Name.Contains(filter)).ToList().Count() >= 1)
                .ToListAsync());
        }

        public async Task<ActionResult> CreateAsync(CreateMedicalBillDto MedicalBillDto)
        {
            if (!await MedicalBillEfc.Create(_mapper.Map<MedicalBill>(MedicalBillDto)))
                throw new System.Exception("an error occurred while creating the MedicalBill");

            return NoContent();
        }

        public async Task<ActionResult> UpdateAsync(UpdateMedicalBillDto MedicalBillDto)
        {
            if (!await MedicalBillEfc.Update(_mapper.Map<MedicalBill>(MedicalBillDto)))
                throw new System.Exception("an error occurred while updating the MedicalBill");

            return NoContent();
        }

        public async Task<ActionResult> ChangeStatusAsync(int id, bool status)
        {
            if (!await MedicalBillEfc.ChangeStatus(id, status))
                throw new System.Exception("an error occurred while changing the MedicalBill status");

            return NoContent();
        }
    }
}
