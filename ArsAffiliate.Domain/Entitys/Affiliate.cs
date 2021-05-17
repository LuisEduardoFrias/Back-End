using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAffiliate.Domain.Entitys
{
    public class Affiliate
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string Nacionality { get; set; }

        [Column(TypeName = "char(1)")]
        [Required]
        public char Sex { get; set; }

        [Column(TypeName = "char(11)")]
        [Required]
        public string IdentificationCard { get; set; }

        [Column(TypeName = "varchar(15)")]
        [Required]
        public string SocialSecurityNumber { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Status { get; set; }

        [Required]
        public int PlanId { get; set; }

        [ForeignKey("PlanId")]
        public Plan Plan { get; set; }

        public ICollection<MedicalBill> MedicalBills { get; set; }
    }
}
