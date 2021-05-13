using ArsAffiliate.Persistence.Data;
using AutoMapper;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.RepositoryEfc
{
    public abstract class RepositoryBaseEfc
    {

        public  readonly PersistencsDataContext _Context;

        public RepositoryBaseEfc(PersistencsDataContext context)
        {
            _Context = context;
        }

        protected async Task<bool> SaveAsync()
        {
            return await _Context.SaveChangesAsync() >= 1;
        }
    }
}
