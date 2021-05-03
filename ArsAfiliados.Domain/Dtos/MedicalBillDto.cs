using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArsAfiliados.Domain.Dtos
{
    public class CreateMedicalBillDto : ErrorDto
    {
        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public bool Status { get; set; }

    }

    public class UpdateMedicalBillDto : CreateMedicalBillDto
    {
        public int Id { get; set; }
    }

    public class ShowMedicalBillDto : UpdateMedicalBillDto
    {
        [Required]
        public ICollection<ShowServiceDto> Services { get; set; }
    }
}
