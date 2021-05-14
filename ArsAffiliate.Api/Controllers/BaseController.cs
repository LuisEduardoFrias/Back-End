using ArsAffiliate.Application.EfcApplications;
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
            applicationAffiliate = AffiliateApplication.GetInstance(context, mapper);
            applicationPlan = PlanEfcApplication.GetInstance(context, mapper);
            applicationService = ServiceEfcApplication.GetInstance(context, mapper);
            applicationBranchOffice = BranchOfficeEfcApplication.GetInstance(context, mapper);
            applicationMedicalBill = MedicalBillEfcApplication.GetInstance(context, mapper);
        }
    }
}
