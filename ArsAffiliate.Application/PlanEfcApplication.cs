﻿using ArsAffiliate.Domain.Dtos.Plan;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Application
{
    public class PlanEfcApplication : BaseApplicationController
    {
        #region Singletom

        public static PlanEfcApplication Instantice { get; set; }

        public static PlanEfcApplication GetInstance(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new PlanEfcApplication(context, mapper);

            return Instantice;
        }

        #endregion

        private PlanEfcApplication(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ActionResult<List<ShowPlanDto>>> ShowAsync(string filter = null)
        {
            var query = PlanEfc.Show();

            if (filter == null)
                return _mapper.Map<List<ShowPlanDto>>(await query.ToListAsync());

            return _mapper.Map<List<ShowPlanDto>>(await query
                .Where(x => x.PlanName.Contains(filter))
                .ToListAsync());
        }

        public async Task<ActionResult> CreateAsync(CreatePlanDto PlanDto)
        {
            if (!await PlanEfc.Create(_mapper.Map<Plan>(PlanDto)))
                throw new System.Exception("an error occurred while creating the Plan");

            return NoContent();
        }

        public async Task<ActionResult> UpdateAsync(UpdatePlanDto PlanDto)
        {
            if (!await PlanEfc.Update(_mapper.Map<Plan>(PlanDto)))
                throw new System.Exception("an error occurred while updating the Plan");

            return NoContent();
        }

        public async Task<ActionResult> ChangeStatusAsync(int id, bool status)
        {
            if (!await PlanEfc.ChangeStatus(id, status))
                throw new System.Exception("an error occurred while changing the Plan status");

            return NoContent();
        }
    }
}