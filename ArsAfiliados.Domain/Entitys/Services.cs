
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAfiliados.Domain.Entitys
{
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Name { get; set; }

        [Required]
        public int PercentCovers { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Status { get; set; }

        [Required]
        public BranchOffice BranchOffice { get; set; }
    }
}
