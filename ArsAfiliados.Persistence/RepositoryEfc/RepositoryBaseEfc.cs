using ArsAfiliados.Persistence.Data;
using AutoMapper;
//

namespace ArsAfiliados.Persistence.RepositoryEfc
{
    public abstract class RepositoryBaseEfc
    {

        public  readonly PersistencsDataContext _Context;
        public  readonly IMapper _Mapper;

        public RepositoryBaseEfc(PersistencsDataContext context, IMapper mapper)
        {
            _Context = context;
            _Mapper = mapper;
        }
    }
}
