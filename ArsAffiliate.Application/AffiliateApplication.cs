﻿using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Application
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

        public async Task<ActionResult<List<ShowAffiliateDto>>> ShowAsync(string filter = null)
        {
            var query = AffiliateEfc.Show();

            if (filter == null)
                return _mapper.Map<List<ShowAffiliateDto>>(await query.ToListAsync());

            return _mapper.Map<List<ShowAffiliateDto>>(await query
                .Where(x => x.IdentificationCard.Contains(filter) || x.Name.Contains(filter))
                .ToListAsync());
        }

        public async Task<ActionResult> CreateAsync(CreateAffiliateDto affiliateDto)
        {
            if (!await AffiliateEfc.Create(_mapper.Map<Affiliate>(affiliateDto)))
                throw new System.Exception("an error occurred while creating the Affiliate");

            return NoContent();
        }

        public async Task<ActionResult> UpdateAsync(UpdateAffiliateDto affiliateDto)
        {
            if (!await AffiliateEfc.Update(_mapper.Map<Affiliate>(affiliateDto)))
                throw new System.Exception("an error occurred while updating the Affiliate");

            return NoContent();
        }

        public async Task<ActionResult> ChangeStatusAsync(int id, bool status)
        {
            if (!await AffiliateEfc.ChangeStatus(id, status))
                throw new System.Exception("an error occurred while changing the affiliate status");

            return NoContent();
        }
    }
}