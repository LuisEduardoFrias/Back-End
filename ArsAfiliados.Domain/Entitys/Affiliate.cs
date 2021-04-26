using System;
//

namespace ArsAfiliados.Domain.Entitys
{
    public class Affiliate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Date { get; set; }

        public string Nacionality { get; set; }

        public char Sex { get; set; }

        public string IdentificationCard { get; set; }

        public string SocialSecurityNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public decimal AmountConsumed { get; set; }

        public bool Status { get; set; }

        public int PlanId { get; set; }

        public Plan Plan { get; set; }
    }
}
