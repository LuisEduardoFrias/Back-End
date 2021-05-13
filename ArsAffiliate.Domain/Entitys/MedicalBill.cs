using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAffiliate.Domain.Entitys
{
    public class MedicalBill
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Status { get; set; }

        [Required]
        public ICollection<Service> Services { get; set; }
    }
}
