using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.Intefaces
{
    public interface IRepositorySearch<T> where T : class
    {
        Task<T> Search(int id);
    }
}
