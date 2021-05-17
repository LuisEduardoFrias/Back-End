using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Persistence.Intefaces;
using ArsAffiliate.Service.EntensionMethods;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public class RepositoryServiceEfc : RepositoryBaseEfc, IRepository<Domain.Entitys.Service>
    {

        #region Singletom

        public static RepositoryServiceEfc Instantice { get; set; }

        public static RepositoryServiceEfc GetInstance(PersistencsDataContext context)
        {
            if (Instantice == null)
                Instantice = new RepositoryServiceEfc(context);

            return Instantice;
        }

        #endregion

        private RepositoryServiceEfc(PersistencsDataContext context) : base(context)
        {

        }

        public IQueryable<Domain.Entitys.Service> Show()
        {
            return _Context.Services.Include(x => x.ServiceDoctors).ThenInclude(x => x.Doctor).Include(x => x.BranchOffice);
        }

        public async Task<bool> Create(Domain.Entitys.Service entity)
        {
            await _Context.Services.AddAsync(entity);

            return await SaveAsync();
        }

        public async Task<bool> Update(Domain.Entitys.Service entity)
        {
            _Context.Services.Update(entity);

            return await SaveAsync();
        }

        public async Task<bool> ChangeStatus(int id, bool status)
        {
            Domain.Entitys.Service service = await _Context.Services.FirstOrDefaultAsync(x => x.Id == id.ToInt());

            if (service == null)
                return false;

            service.Status = status;

            return await SaveAsync();
        }
    }
}
