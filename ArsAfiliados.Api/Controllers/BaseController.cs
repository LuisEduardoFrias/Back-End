using ArsAfiliados.Persistence.Intefaces;
using ArsAfiliados.Persistence.RepositoryAdo;
using Microsoft.AspNetCore.Mvc;

namespace ArsAfiliados.Api.Controllers
{
    public class BaseController : Controller
    {
        public readonly RepositoryAffiliateAdo Affiliate;
        public readonly RepositoryPlanAdo Plan;

        public BaseController()
        {
            Affiliate = RepositoryAffiliateAdo.GetInstance();
            Plan = RepositoryPlanAdo.GetInstance();
        }
    }
}
