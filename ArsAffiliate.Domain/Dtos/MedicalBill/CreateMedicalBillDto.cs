using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos.MedicalBill
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
}
