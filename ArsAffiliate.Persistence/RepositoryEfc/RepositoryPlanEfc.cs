using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public class RepositoryPlanEfc : RepositoryBaseEfc, IRepository<Plan>, IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryPlanEfc Instantice { get; set; }

        public static RepositoryPlanEfc GetInstance(PersistencsDataContext context)
        {
            if (Instantice == null)
                Instantice = new RepositoryPlanEfc(context);

            return Instantice;
        }

        #endregion

        private RepositoryPlanEfc(PersistencsDataContext context) : base(context)
        {

        }

        public IQueryable<Plan> Show()
        {
            return _Context.Plans;
        }

        public async Task<bool> Create(Plan entity)
        {
            await _Context.Plans.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> Update(Plan entity)
        {
            _Context.Plans.Update(entity);

            return await SaveAsync();
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {
            Plan plan = await _Context.Plans.FirstOrDefaultAsync(x => x.Id == id.ToInt());

            if (plan == null)
                return false;

            plan.Status = status;

            return await SaveAsync();
        }
    }
}

