using System.Threading.Tasks;

namespace ArsAfiliados.Persistence.Intefaces
{
    public interface IRepositorySearch<S> where S : class
    {
        Task<S> Search(string identity);
    }
}
