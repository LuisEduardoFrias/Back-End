using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAfiliados.Domain.Dtos
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

    public class UpdatePlanDto : CreatePlanDto
    {
        public int Id { get; set; }
    }

    public class ShowPlanDto : UpdatePlanDto
    {

    }
}
