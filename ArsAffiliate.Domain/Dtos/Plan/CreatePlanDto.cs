using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos.Plan
{
    public class CreatePlanDto : ErrorDto
    {
        [Required]
        public string PlanName { get; set; }

        [Required]
        public decimal CoverageAmount { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
