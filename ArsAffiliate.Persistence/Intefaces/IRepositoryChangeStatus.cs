using System;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.Intefaces
{
    public interface IRepositoryChangeStatus
    {
        Task<bool> ChangeStatus(Guid  id, bool status);
    }
}
