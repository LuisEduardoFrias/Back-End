using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAffiliate.Domain.Entitys
{
    public class BranchOffice
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Address { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Status { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
