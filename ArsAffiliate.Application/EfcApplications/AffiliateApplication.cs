using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArsAffiliate.Application.EfcApplications
{
    public class AffiliateApplication : BaseApplicationController
    {
        #region Singletom

        public static AffiliateApplication Instantice { get; set; }

        public static AffiliateApplication GetInstance(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new AffiliateApplication(context, mapper);

            return Instantice;
        }

        #endregion

        private AffiliateApplication(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<ShowAffiliateDto>> ShowAsync(string filter = null)
        {
            IQueryable<Affiliate> query = AffiliateEfc.Show();

            if (filter == null)
                return mapper.Map<List<ShowAffiliateDto>>(await query.ToListAsync());

            return mapper.Map<List<ShowAffiliateDto>>(
                    await query
                    .Where(x => x.IdentificationCard.Contains(filter) || x.Name.Contains(filter))
                    .ToListAsync());
        }

        public async Task<ShowAffiliateDto> ShowAsync(Guid id)
        {
            IQueryable<Affiliate> query = AffiliateEfc.Show();

            Affiliate affiliate = await query.FirstOrDefaultAsync(x => x.Id.CompareTo(id) == 0);

            if (affiliate == null)
                throw new HttpResponseException { MensajeError = "", StatusCode = HttpStatusCode.NotFound };

            return mapper.Map<ShowAffiliateDto>(affiliate);
        }


        public async Task<List<ShowAffiliateDto>> AmountConsumed(int id, DateTime sinceDate, DateTime tillDate)
        {
            Affiliate afiliate = await AffiliateEfc.AmountConsumedAsync(id);

            if (afiliate == null)
            {
                IEnumerable<MedicalBill> medicalBills = afiliate.MedicalBills.Where(x => x.RegistrationDate.CompareTo(sinceDate) == 0 && x.RegistrationDate.CompareTo(tillDate) == 0);


                return mapper.Map<List<ShowAffiliateDto>>(medicalBills);
            }

            throw new HttpResponseException { MensajeError = "There are no records ... ", StatusCode = HttpStatusCode.BadRequest };
        }

        public async Task CreateAsync(CreateAffiliateDto affiliateDto)
        {
            if (!await AffiliateEfc.Create(mapper.Map<Affiliate>(affiliateDto)))
                throw new HttpResponseException { MensajeError = "There are no records ... " };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }

        public async Task UpdateAsync(UpdateAffiliateDto affiliateDto)
        {
            if (!await AffiliateEfc.Update(mapper.Map<Affiliate>(affiliateDto)))
                throw new HttpResponseException { MensajeError = "an error occurred while updating the Affiliate" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }

        public async Task ChangeStatusAsync(int id, bool status)
        {
            if (!await AffiliateEfc.ChangeStatus(id, status))
                throw new HttpResponseException { MensajeError = "an error occurred while changing the affiliate status" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }
    }
}
