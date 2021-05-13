using ArsAffiliate.Domain.Dtos.Plan;

namespace ArsAffiliate.Domain.Dtos.Affiliate
{
    public class ShowAffiliateDto : UpdateAffiliateDto
    {
        public ShowPlanDto Plan { get; set; }

        public string PlanName => Plan.PlanName;

        public decimal CoverageAmount => Plan.CoverageAmount;
    }
}
