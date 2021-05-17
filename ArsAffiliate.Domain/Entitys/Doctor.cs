using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAffiliate.Domain.Entitys
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(25)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string BranchMedicine { get; set; }

        public int WorkingHoursId { get; set; }

        [ForeignKey("WorkingHoursId")]
        public WorkingHour WorkingHours { get; set; }

        public ICollection<ServiceDoctor> ServiceDoctors { get; set; }
    }
}
