using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Domain.Entitys;
using ArsAfiliados.Persistence.Data;
using ArsAfiliados.Persistence.Intefaces;
using ArsAfiliados.Service.EntensionMethods;
using System.Linq;
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public class RepositoryPlanEfc : RepositoryBaseEfc, 
                                     IRepository<CreatePlanDto, UpdatePlanDto, ShowPlanDto>,
                                     IRepositorySearch<ShowPlanDto>,
                                     IRepositoryChangeStatus
    {

        #region Singletom

        private static RepositoryPlanEfc Instance;

        public static RepositoryPlanEfc GetInstance(PersistencsDataContext context, IMapper mapper)
        {
            if (Instance == null)
                Instance = new RepositoryPlanEfc(context, mapper);

            return Instance;
        }

        #endregion

        private RepositoryPlanEfc(PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public async Task<List<ShowPlanDto>> Show()
        {
            try
            {
                return _Mapper.Map<List<ShowPlanDto>>(await _Context.Plans.ToListAsync());
            }
            catch
            {
                return new List<ShowPlanDto>() { new ShowPlanDto { IsError = true } };
            }
        }

        public async Task<List<ShowPlanDto>> ShowAllWhereStatusTrue()
        {
            try
            {
                return _Mapper.Map<List<ShowPlanDto>>(await _Context.Plans.Where(x => x.Status == true).ToListAsync());
            }
            catch
            {
                return new List<ShowPlanDto>() { new ShowPlanDto { IsError = true } };
            }
        }

        public async Task<bool> Create(CreatePlanDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.Plans.AddAsync(_Mapper.Map<Plan>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<bool> Update(UpdatePlanDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.Plans.AddAsync(_Mapper.Map<Plan>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<ShowPlanDto> Search(string identity)
        {
            try
            {
                return _Mapper.Map<ShowPlanDto>(await _Context.Plans.FirstOrDefaultAsync(x => x.PlanName == identity));
            }
            catch
            {
                return new ShowPlanDto() { IsError = true };
            }
        }

        public async Task<bool> ChangeStatus(string identity, bool status)
        {
            bool result = false;

            try
            {
                var plan = await _Context.Plans.FirstOrDefaultAsync(x => x.Id == identity.ToInt());
                plan.Status = status;

                await _Context.SaveChangesAsync();

                result = true;
            }
            catch { }


            return result;
        }

    }
}

