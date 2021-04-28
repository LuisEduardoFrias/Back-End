using AutoMapper;
using Microsoft.AspNetCore.Mvc;
//
using ArsAfiliados.Persistence.RepositoryAdo;
using ArsAfiliados.Persistence.RepositoryEfc;
//

namespace ArsAfiliados.Api.Controllers
{
    public class BaseController : Controller
    {
        public readonly RepositoryAffiliateAdo AffiliateAdo;
        public readonly RepositoryPlanAdo PlanAdo;

        public readonly RepositoryAffiliateEfc AffiliateEfc;
        public readonly RepositoryPlanEfc PlanEfc;

        public BaseController()
        {
            AffiliateAdo = RepositoryAffiliateAdo.GetInstance();
            PlanAdo = RepositoryPlanAdo.GetInstance();
        }

        public BaseController(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            AffiliateEfc = RepositoryAffiliateEfc.GetInstance(context, mapper);
            PlanEfc = RepositoryPlanEfc.GetInstance(context, mapper);
        }
    }
}
