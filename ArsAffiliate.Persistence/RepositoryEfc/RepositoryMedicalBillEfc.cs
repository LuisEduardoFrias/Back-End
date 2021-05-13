using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public class RepositoryMedicalBillEfc : RepositoryBaseEfc, IRepository<MedicalBill>, IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryMedicalBillEfc Instantice { get; set; }

        public static RepositoryMedicalBillEfc GetInstance(PersistencsDataContext context)
        {
            if (Instantice == null)
                Instantice = new RepositoryMedicalBillEfc(context);

            return Instantice;
        }

        #endregion

        private RepositoryMedicalBillEfc(PersistencsDataContext context) : base(context)
        {

        }

        public IQueryable<MedicalBill> Show()
        {
            return _Context.MedicalBills.Include(x => x.Services).ThenInclude(x => x.BranchOffice);
        }

        public async Task<bool> Create(MedicalBill entity)
        {
            await _Context.MedicalBills.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> Update(MedicalBill entity)
        {
            _Context.MedicalBills.Update(entity);

            return await SaveAsync();
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {
            MedicalBill medicalBill = await _Context.MedicalBills.FirstOrDefaultAsync(x => x.Id == id.ToInt());

            if (medicalBill == null)
                return false;

            medicalBill.Status = status;

            return await SaveAsync();
        }
    }
}

