using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos.Service
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
}
