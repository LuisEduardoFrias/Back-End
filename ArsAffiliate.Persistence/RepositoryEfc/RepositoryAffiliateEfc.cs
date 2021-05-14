using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public class RepositoryAffiliateEfc : RepositoryBaseEfc, IRepository<Affiliate>, IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryAffiliateEfc Instantice { get; set; }

        public static RepositoryAffiliateEfc GetInstance(PersistencsDataContext context)
        {
            if (Instantice == null)
                Instantice = new RepositoryAffiliateEfc(context);

            return Instantice;
        }

        #endregion

        private RepositoryAffiliateEfc(PersistencsDataContext context) : base(context)
        {

        }

        public IQueryable<Affiliate> Show()
        {
            return _Context.Affiliates;
        }

        public async Task<bool> Create(Affiliate entity)
        {
            await _Context.Affiliates.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> Update(Affiliate entity)
        {
            _Context.Affiliates.Update(entity);

            return await SaveAsync();
        }

        public async Task<Affiliate> AmountConsumedAsync(int id)
        {
            return await _Context.Affiliates.Include(x => x.MedicalBills).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {
            Affiliate affiliate = await _Context.Affiliates.FirstOrDefaultAsync(x => x.Id == id.ToInt());

            if (affiliate == null)
                return false;

            affiliate.Status = status;

            return await SaveAsync();
        }

        public async Task<bool> UpdateAmountAffiliate(int id, decimal newAmountConsumed)
        {
            Affiliate affiliate = await _Context.Affiliates.FirstOrDefaultAsync(x => x.Id == id);

            affiliate.AmountConsumed = newAmountConsumed;

            return await SaveAsync();
        }
    }
}
