using System.Threading.Tasks;

namespace ArsAfiliados.Persistence.Intefaces
{
    public interface IRepositoryChangeStatus
    {
        Task<bool> ChangeStatus(string identity, bool status);
    }
}
