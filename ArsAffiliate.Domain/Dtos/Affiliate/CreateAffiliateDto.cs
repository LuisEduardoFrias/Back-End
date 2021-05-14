using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos.Affiliate
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
        public bool Status { get; set; }

        [Required]
        public int PlanId { get; set; }
    }
}
