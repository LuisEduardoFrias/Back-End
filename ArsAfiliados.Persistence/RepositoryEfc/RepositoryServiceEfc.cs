using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Persistence.Data;
using ArsAfiliados.Persistence.Intefaces;
using ArsAfiliados.Service.EntensionMethods;
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public class RepositoryServiceEfc : RepositoryBaseEfc, 
                                        IRepository<CreateServiceDto, UpdateServiceDto, ShowServiceDto>,
                                        IRepositorySearch<ShowServiceDto>,
                                        IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryServiceEfc Instantice { get; set; }

        public static RepositoryServiceEfc GetInstance(PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new RepositoryServiceEfc(context, mapper);

            return Instantice;
        }

        #endregion

        private RepositoryServiceEfc(PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public async Task<List<ShowServiceDto>> Show()
        {
            try
            {
                return _Mapper.Map<List<ShowServiceDto>>(await _Context.Services.ToListAsync());
            }
            catch
            {
                return new List<ShowServiceDto>() { new ShowServiceDto { IsError = true } };
            }
        }

        public async Task<bool> Create(CreateServiceDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.Services.AddAsync(_Mapper.Map<ArsAfiliados.Domain.Entitys.Service>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<bool> Update(UpdateServiceDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.Services.AddAsync(_Mapper.Map<ArsAfiliados.Domain.Entitys.Service>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<ShowServiceDto> Search(string identity)
        {
            try
            {
                return _Mapper.Map<ShowServiceDto>(await _Context.Services.FirstOrDefaultAsync(x => x.Name == identity));
            }
            catch
            {
                return new ShowServiceDto() { IsError = true };
            }
        }

        public async Task<bool> ChangeStatus(string identity, bool status)
        {
            bool result = false;

            try
            {
                var affiliate = await _Context.Services.FirstOrDefaultAsync(x => x.Id == identity.ToInt());
                affiliate.Status = status;

                await _Context.SaveChangesAsync();

                result = true;
            }
            catch { }


            return result;
        }
    }
}
