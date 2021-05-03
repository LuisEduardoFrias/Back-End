using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAfiliados.Domain.Dtos
{
    public class CreateAffiliateDto : ErrorDto
    {
        [Required]
        public string IdentificationCard { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Nacionality { get; set; }

        [Required]
        public char Sex { get; set; }

        [Required]
        public string SocialSecurityNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public decimal AmountConsumed { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
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

        public decimal CoverageAmount  => Plan.CoverageAmount;

    }

    public class UpdateAmountAffiliateDto : UpdateAffiliateDto
    {
        public decimal NewAmount { get; set; }

    }
}
