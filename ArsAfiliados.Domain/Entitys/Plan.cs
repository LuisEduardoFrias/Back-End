using System;
//

namespace ArsAfiliados.Domain.Entitys
{
    public class Plan
    {
        public int Id { get; set; }

        public string PlanName { get; set; }

        public decimal CoverageAmount { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Status { get; set; }
    }
}
