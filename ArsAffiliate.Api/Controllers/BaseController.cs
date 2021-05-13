using ArsAffiliate.Application;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArsAffiliate.Api.Controllers
{
    public class BaseController : Controller
    {
        //public readonly RepositoryAffiliateAdo AffiliateAdo;
        //public readonly RepositoryPlanAdo PlanAdo;

        protected readonly AffiliateApplication applicationAffiliate;
        protected readonly PlanEfcApplication applicationPlan;
        protected readonly ServiceEfcApplication applicationService;
        protected readonly BranchOfficeEfcApplication applicationBranchOffice;
        protected readonly MedicalBillEfcApplication applicationMedicalBill;


        public BaseController()
        {
            //AffiliateAdo = RepositoryAffiliateAdo.GetInstance();
            //PlanAdo = RepositoryPlanAdo.GetInstance();
        }

        public BaseController(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            applicationAffiliate = AffiliateApplication.GetInstance( mapper);
            applicationPlan = PlanEfcApplication.GetInstance(mapper);
            applicationService = ServiceEfcApplication.GetInstance(mapper);
            applicationBranchOffice = BranchOfficeEfcApplication.GetInstance(mapper);
            applicationMedicalBill = MedicalBillEfcApplication.GetInstance(mapper);
        }
    }
}
