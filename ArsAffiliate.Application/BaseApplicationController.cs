using ArsAffiliate.Persistence.RepositoryAdo;
using ArsAffiliate.Persistence.RepositoryEfc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArsAffiliate.Application
{
    public class BaseApplicationController : Controller
    {
        protected readonly IMapper _mapper;

        public readonly RepositoryAffiliateAdo AffiliateAdo;
        public readonly RepositoryPlanAdo PlanAdo;

        public readonly RepositoryAffiliateEfc AffiliateEfc;
        public readonly RepositoryPlanEfc PlanEfc;
        public readonly RepositoryServiceEfc ServiceEfc;
        public readonly RepositoryBranchOfficeEfc BranchOfficeEfc;
        public readonly RepositoryMedicalBillEfc MedicalBillEfc;

        public BaseApplicationController()
        {
            AffiliateAdo = RepositoryAffiliateAdo.GetInstance();
            PlanAdo = RepositoryPlanAdo.GetInstance();
        }

        public BaseApplicationController(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            _mapper = mapper;

            AffiliateEfc = RepositoryAffiliateEfc.GetInstance(context);
            PlanEfc = RepositoryPlanEfc.GetInstance(context);
            ServiceEfc = RepositoryServiceEfc.GetInstance(context);
            BranchOfficeEfc = RepositoryBranchOfficeEfc.GetInstance(context);
            MedicalBillEfc = RepositoryMedicalBillEfc.GetInstance(context);
        }
    }
}
