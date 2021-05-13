using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public class RepositoryBranchOfficeEfc : RepositoryBaseEfc, IRepository<BranchOffice>, IRepositoryChangeStatus
    {

        #region Singletom

        public static RepositoryBranchOfficeEfc Instantice { get; set; }

        public static RepositoryBranchOfficeEfc GetInstance(PersistencsDataContext context)
        {
            if (Instantice == null)
                Instantice = new RepositoryBranchOfficeEfc(context);

            return Instantice;
        }

        #endregion

        private RepositoryBranchOfficeEfc(PersistencsDataContext context) : base(context)
        {

        }

        public IQueryable<BranchOffice> Show()
        {
            return _Context.BranchOffices;
        }

        public async Task<bool> Create(BranchOffice entity)
        {
            await _Context.BranchOffices.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> Update(BranchOffice entity)
        {
            _Context.BranchOffices.Update(entity);

            return await SaveAsync();
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {
            BranchOffice branchOffice = await _Context.BranchOffices.FirstOrDefaultAsync(x => x.Id == id.ToInt());

            if (branchOffice == null)
                return false;

            branchOffice.Status = status;

            return await SaveAsync();
        }
    }
}
