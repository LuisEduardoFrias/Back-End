using ArsAffiliate.Domain.Dtos.MedicalBill;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                return mapper.Map<List<ShowMedicalBillDto>>(await query.ToListAsync());

            return mapper.Map<List<ShowMedicalBillDto>>(await query
                .Where(x => 
                x.RegistrationDate.ToString("dd/MM/yyyy").Contains(filter) || 
                x.Services.Where(x =>
                x.BranchOffice.Name.Contains(filter)).ToList().Count() >= 1)
                .ToListAsync());
        }

        public async Task<ActionResult> CreateAsync(CreateMedicalBillDto medicalBillDto)
        {
            IQueryable<MedicalBill> queryMedicalBill = MedicalBillEfc.Show();
            IQueryable<BranchOffice> queryBranOffice = BranchOfficeEfc.Show();
            IQueryable<Domain.Entitys.Service> queryService = ServiceEfc.Show();

            decimal totalCostToMonth = await queryMedicalBill.Where(x => x.RegistrationDate.CompareTo(DateTime.Now) >= 0 &
                             x.RegistrationDate.CompareTo(DateTime.Now) <= 30 &
                             x.Affiliate.Id == medicalBillDto.AffiliateId).SumAsync(x => x.TotalCost);

            decimal CoverageAmount = (await queryMedicalBill.FirstOrDefaultAsync(x => 
            x.Affiliate.Id == medicalBillDto.AffiliateId)).Affiliate.Plan.CoverageAmount;


            Domain.Entitys.Service service = (await queryBranOffice
                .FirstOrDefaultAsync(x => x.Id.CompareTo(medicalBillDto.BranchOfficeId) == 0))
                .Services.FirstOrDefault(x => x.Id == medicalBillDto.ServiceId);

            decimal coverage = service.PercentCovers;
            decimal cost = service.Cost;

            decimal totalCoverage = cost * (coverage / 100);


            bool isError = !await MedicalBillEfc.Create(mapper.Map<MedicalBill>(MedicalBillDto));



            if (isError)
                throw new HttpResponseException { MensajeError = "an error occurred while creating the MedicalBill" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }

        public async Task<ActionResult> UpdateAsync(UpdateMedicalBillDto MedicalBillDto)
        {
            if (!await MedicalBillEfc.Update(mapper.Map<MedicalBill>(MedicalBillDto)))
                throw new HttpResponseException { MensajeError = "an error occurred while updating the MedicalBill" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }

        public async Task<ActionResult> ChangeStatusAsync(int id, bool status)
        {
            if (!await MedicalBillEfc.ChangeStatus(id, status))
                throw new HttpResponseException { MensajeError = "an error occurred while changing the MedicalBill status" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }
    }
}
