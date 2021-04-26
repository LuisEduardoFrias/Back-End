using System;

namespace ArsAfiliados.Domain.Dtos
{
    public class CreateAffiliateDto : ErrorDto
    {
        public string IdentificationCard { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public string Nacionality { get; set; }

        public char Sex { get; set; }

        public string SocialSecurityNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public decimal AmountConsumed { get; set; }

        public bool Status { get; set; }

        public int PlanId { get; set; }

    }

    public class UpdateAffiliateDto : CreateAffiliateDto
    {
        public int Id { get; set; }
    }

    public class ShowAffiliateDto : UpdateAffiliateDto
    {
        public ShowPlanDto Plan { get; set; }

        public string PlanName => Plan.PlanName;

        public decimal MontoCobertura => Plan.CoverageAmount;

    }

    public class UpdateAmountAffiliateDto : UpdateAffiliateDto
    {
        public decimal NewAmount { get; set; }

    }
}
