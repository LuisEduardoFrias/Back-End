using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.RepositoryAdo;
using ArsAffiliate.Persistence.RepositoryEfc;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ArsAffiliate.Application
{
    public class BaseApplicationController : Controller
    {
        protected readonly IMapper mapper;

        public readonly RepositoryAffiliateAdo AffiliateAdo;
        public readonly RepositoryPlanAdo PlanAdo;

        public readonly RepositoryAffiliateEfc AffiliateEfc;
        public readonly RepositoryPlanEfc PlanEfc;
        public readonly RepositoryServiceEfc ServiceEfc;
        public readonly RepositoryBranchOfficeEfc BranchOfficeEfc;
        public readonly RepositoryMedicalBillEfc MedicalBillEfc;

        public readonly RepositoryUserEfc AccountEfc;

        public BaseApplicationController()
        {
            AffiliateAdo = RepositoryAffiliateAdo.GetInstance();
            PlanAdo = RepositoryPlanAdo.GetInstance();
        }

        public BaseApplicationController(Persistence.Data.PersistencsDataContext context, IMapper mapper)
        {
            this.mapper = mapper;

            AffiliateEfc = RepositoryAffiliateEfc.GetInstance(context);
            PlanEfc = RepositoryPlanEfc.GetInstance(context);
            ServiceEfc = RepositoryServiceEfc.GetInstance(context);
            BranchOfficeEfc = RepositoryBranchOfficeEfc.GetInstance(context);
            MedicalBillEfc = RepositoryMedicalBillEfc.GetInstance(context);
        }        
        
        public BaseApplicationController(UserManager<User> userManager, SignInManager<User> signManager, IMapper mapper)
        {
            this.mapper = mapper;

            AccountEfc = RepositoryUserEfc.GetInstance(userManager, signManager);
        }
    }
}
