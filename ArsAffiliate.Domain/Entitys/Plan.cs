using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAffiliate.Domain.Entitys
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required]
        public string PlanName { get; set; }

        [Required]
        public decimal CoverageAmount { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Status { get; set; }
    }
}
