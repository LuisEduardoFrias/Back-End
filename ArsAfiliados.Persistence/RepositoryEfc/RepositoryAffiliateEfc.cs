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
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public class RepositoryAffiliateEfc : RepositoryBaseEfc, 
                                          IRepository<CreateAffiliateDto, UpdateAffiliateDto, ShowAffiliateDto>,
                                          IRepositorySearch<ShowAffiliateDto>,
                                          IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryAffiliateEfc Instantice { get; set; }

        public static RepositoryAffiliateEfc GetInstance(PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new RepositoryAffiliateEfc(context, mapper);

            return Instantice;
        }

        #endregion

        private RepositoryAffiliateEfc(PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public async Task<List<ShowAffiliateDto>> Show()
        {
            try
            {
                return _Mapper.Map<List<ShowAffiliateDto>>(await _Context.Affiliates.ToListAsync());
            }
            catch
            {
                return new List<ShowAffiliateDto>() { new ShowAffiliateDto { IsError = true } };
            }
        }

        public async Task<bool> Create(CreateAffiliateDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.Affiliates.AddAsync(_Mapper.Map<Affiliate>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<bool> Update(UpdateAffiliateDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.Affiliates.AddAsync(_Mapper.Map<Affiliate>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<ShowAffiliateDto> Search(string identity)
        {
            try
            {
                return _Mapper.Map<ShowAffiliateDto>(await _Context.Affiliates.FirstOrDefaultAsync(x => x.IdentificationCard == identity));
            }
            catch
            {
                return new ShowAffiliateDto() { IsError = true };
            }
        }

        public async Task<bool> ChangeStatus(string identity, bool status)
        {
            bool result = false;

            try
            {
                var affiliate = await _Context.Affiliates.FirstOrDefaultAsync(x => x.Id == identity.ToInt());
                affiliate.Status = status;

                await _Context.SaveChangesAsync();

                result = true;
            }
            catch { }


            return result;
        }

        public async Task<bool> UpdateAmountAffiliate(string IdentificationCard, decimal NewAmountConsumed)
        {
            bool result = false;

            try
            {
                var affiliate = await _Context.Affiliates.FirstOrDefaultAsync(x => x.IdentificationCard == IdentificationCard);

                affiliate.AmountConsumed = NewAmountConsumed;

                await _Context.SaveChangesAsync();

                result = true;
            }
            catch { }

            return result;
        }

    }
}
