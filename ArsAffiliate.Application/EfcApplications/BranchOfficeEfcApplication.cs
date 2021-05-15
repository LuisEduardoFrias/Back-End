using ArsAffiliate.Domain.Dtos.BranchOffice;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ArsAffiliate.Application.EfcApplications
{
    public class BranchOfficeEfcApplication : BaseApplicationController
    {
        #region Singletom

        public static BranchOfficeEfcApplication Instantice { get; set; }

        public static BranchOfficeEfcApplication GetInstance(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new BranchOfficeEfcApplication(context, mapper);

            return Instantice;
        }

        #endregion

        private BranchOfficeEfcApplication(Persistence.Data.PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ActionResult<List<ShowBranchOfficeDto>>> ShowAsync(string filter = null)
        {
            IQueryable<BranchOffice> query = BranchOfficeEfc.Show();

            if (filter == null)
                return _mapper.Map<List<ShowBranchOfficeDto>>(await query.ToListAsync());

            return _mapper.Map<List<ShowBranchOfficeDto>>(await query
                .Where(x => x.Address.Contains(filter) || x.Name.Contains(filter) || x.Id.ToString().Contains(filter))
                .ToListAsync());
        }

        public async Task<ActionResult> CreateAsync(CreateBranchOfficeDto BranchOfficeDto)
        {
            if (!await BranchOfficeEfc.Create(_mapper.Map<BranchOffice>(BranchOfficeDto)))
                throw new HttpResponseException { MensajeError = "an error occurred while creating the BranchOffice" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }

        public async Task<ActionResult> UpdateAsync(UpdateBranchOfficeDto BranchOfficeDto)
        {
            if (!await BranchOfficeEfc.Update(_mapper.Map<BranchOffice>(BranchOfficeDto)))
                throw new HttpResponseException { MensajeError = "an error occurred while updating the BranchOffice" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }

        public async Task<ActionResult> ChangeStatusAsync(int id, bool status)
        {
            if (!await BranchOfficeEfc.ChangeStatus(id, status))
                throw new HttpResponseException { MensajeError = "an error occurred while changing the BranchOffice status" };

            throw new HttpResponseException { StatusCode = HttpStatusCode.NoContent };
        }
    }
}
