﻿using ArsAffiliate.Domain.Dtos.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Application.EfcApplications
{
    public class ServiceEfcApplication : BaseApplicationController
    {
        #region Singletom

        public static ServiceEfcApplication Instantice { get; set; }

        public static ServiceEfcApplication GetInstance(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new ServiceEfcApplication(context, mapper);

            return Instantice;
        }

        #endregion

        private ServiceEfcApplication(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ActionResult<List<ShowServiceDto>>> ShowAsync(string filter = null)
        {
            IQueryable<Domain.Entitys.Service> query = ServiceEfc.Show();

            if (filter == null)
                return _mapper.Map<List<ShowServiceDto>>(await query.ToListAsync());

            return _mapper.Map<List<ShowServiceDto>>(await query
                .Where(x => x.Name.Contains(filter))
                .ToListAsync());
        }

        public async Task<ActionResult> CreateAsync(CreateServiceDto affiliateDto)
        {
            if (!await ServiceEfc.Create(_mapper.Map<Domain.Entitys.Service>(affiliateDto)))
                throw new System.Exception("an error occurred while creating the Service");

            return NoContent();
        }

        public async Task<ActionResult> UpdateAsync(UpdateServiceDto affiliateDto)
        {
            if (!await ServiceEfc.Update(_mapper.Map<Domain.Entitys.Service>(affiliateDto)))
                throw new System.Exception("an error occurred while updating the Service");

            return NoContent();
        }

        public async Task<ActionResult> ChangeStatusAsync(int id, bool status)
        {
            if (!await ServiceEfc.ChangeStatus(id, status))
                throw new System.Exception("an error occurred while changing the Service status");

            return NoContent();
        }
    }
}