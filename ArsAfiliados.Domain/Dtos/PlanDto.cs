using System;
using System.Collections.Generic;
using System.Text;

namespace ArsAfiliados.Domain.Dtos
{
    public class CreatePlanDto : ErrorDto
    {
        public string PlanName { get; set; }
        
        public decimal CoverageAmount { get; set; }
        
        public DateTime RegistrationDate { get; set; }

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
