using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Persistence.Data;
using ArsAfiliados.Persistence.Intefaces;
using ArsAfiliados.Domain.Entitys;
using ArsAfiliados.Service.EntensionMethods;
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public class RepositoryMedicalBillEfc : RepositoryBaseEfc, 
                                            IRepository<CreateMedicalBillDto, UpdateMedicalBillDto, ShowMedicalBillDto>,
                                            IRepositorySearch<ShowMedicalBillDto>
    {

        #region Singletom

        public static RepositoryMedicalBillEfc Instantice { get; set; }

        public static RepositoryMedicalBillEfc GetInstance(PersistencsDataContext context, IMapper mapper)
        {
            if (Instantice == null)
                Instantice = new RepositoryMedicalBillEfc(context, mapper);

            return Instantice;
        }

        #endregion

        private RepositoryMedicalBillEfc(PersistencsDataContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public async Task<List<ShowMedicalBillDto>> Show()
        {
            try
            {
                return _Mapper.Map<List<ShowMedicalBillDto>>(await _Context.MedicalBills.ToListAsync());
            }
            catch
            {
                return new List<ShowMedicalBillDto>() { new ShowMedicalBillDto { IsError = true } };
            }
        }

        public async Task<bool> Create(CreateMedicalBillDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.MedicalBills.AddAsync(_Mapper.Map<MedicalBill>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<bool> Update(UpdateMedicalBillDto entityDto)
        {
            bool resul = false;

            try
            {
                await _Context.MedicalBills.AddAsync(_Mapper.Map<MedicalBill>(entityDto));

                await _Context.SaveChangesAsync();

                resul = true;
            }
            catch { }

            return resul;
        }

        public async Task<ShowMedicalBillDto> Search(string identity)
        {
            try
            {
                return _Mapper.Map<ShowMedicalBillDto>(await _Context.MedicalBills.FirstOrDefaultAsync(x => x.Id == identity.ToInt()));
            }
            catch
            {
                return new ShowMedicalBillDto() { IsError = true };
            }
        }

    }
}
