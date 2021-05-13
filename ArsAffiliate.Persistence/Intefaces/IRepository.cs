using System.Linq;
using System.Threading.Tasks;

namespace ArsAffiliate.Persistence.Intefaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Show();

        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

    }
}
