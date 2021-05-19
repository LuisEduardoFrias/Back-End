using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos.MedicalBill
{
    public class CreateMedicalBillDto : ErrorDto
    {
        [Required]
        public Guid BranchOfficeId { get; set; }

        public int ServiceId { get; set; }

        [Required]
        public Guid AffiliateId { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public bool Status { get; set; }

    }
}
