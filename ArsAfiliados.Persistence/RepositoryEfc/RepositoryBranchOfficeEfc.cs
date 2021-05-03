using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Persistence.Data;
using ArsAfiliados.Persistence.Intefaces;
using ArsAfiliados.Domain.Entitys;
using ArsAfiliados.Service.EntensionMethods;
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public class RepositoryBranchOfficeEfc : RepositoryBaseEfc, 
                                             IRepository<CreateBranchOfficeDto, UpdateBranchOfficeDto, ShowBranchOfficeDto>,
                                             IRepositorySearch<ShowBranchOfficeDto>,
                                             IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryBranchOfficeEfc Instantice { get; set; }

        public static RepositoryBranchOfficeEfc GetInstance(PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new RepositoryBranchOfficeEfc(context, mapper);

            return Instantice;
        }

        #endregion

        private RepositoryBranchOfficeEfc(PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public async Task<List<ShowBranchOfficeDto>> Show()
        {
            try
            {
                return _Mapper.Map<List<ShowBranchOfficeDto>>(await _Context.BranchOffices
                    .Where(x => x.Services.Count > 0)
                    .ToListAsync());
            }
            catch
            {
                return new List<ShowBranchOfficeDto>() { new ShowBranchOfficeDto { IsError = true } };
            }
        }

        public async Task<bool> Create(CreateBranchOfficeDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.BranchOffices.AddAsync(_Mapper.Map<BranchOffice>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<bool> Update(UpdateBranchOfficeDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.BranchOffices.AddAsync(_Mapper.Map<BranchOffice>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<ShowBranchOfficeDto> Search(string identity)
        {
            try
            {
                return _Mapper.Map<ShowBranchOfficeDto>(await _Context.BranchOffices
                    .FirstOrDefaultAsync(x => x.Name == identity));
            }
            catch
            {
                return new ShowBranchOfficeDto() { IsError = true };
            }
        }

        public async Task<bool> ChangeStatus(string identity, bool status)
        {
            bool result = false;

            try
            {
                var affiliate = await _Context.BranchOffices.FirstOrDefaultAsync(x => x.Id == identity.ToInt());
                affiliate.Status = status;

                await _Context.SaveChangesAsync();

                result = true;
            }
            catch { }


            return result;
        }
    }
}
