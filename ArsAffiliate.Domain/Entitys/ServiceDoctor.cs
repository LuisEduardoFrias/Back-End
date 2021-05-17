using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAffiliate.Domain.Entitys
{
    public class ServiceDoctor
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public int DoctorId { get; set; }

        [Required]
        public int serviceId { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        [ForeignKey("serviceId")]
        public Service service { get; set; }
    }
}
