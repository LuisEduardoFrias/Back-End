using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAfiliados.Domain.Dtos
{
    public class CreateServiceDto : ErrorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int PercentCovers { get; set; }

        [Required]
        public bool Status { get; set; }
    }

    public class UpdateServiceDto : CreateServiceDto
    {
        public int Id { get; set; }
    }

    public class ShowServiceDto : UpdateServiceDto
    {
        [Required]
        public ShowBranchOfficeDto BranchOffice { get; set; }
    }
}
