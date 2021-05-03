using System.Collections.Generic;
using System.Threading.Tasks;
//

namespace ArsAfiliados.Persistence.Intefaces
{
    public interface IRepository<C, U, S> where C : class where U : class where S : class
    {
        Task<List<S>> Show();

        Task<bool> Create(C entityDto);

        Task<bool> Update(U entityDto);

    }
}
