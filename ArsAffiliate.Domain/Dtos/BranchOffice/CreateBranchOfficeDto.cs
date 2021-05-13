using System;
using System.ComponentModel.DataAnnotations;

namespace ArsAffiliate.Domain.Dtos.BranchOffice
{
    public class CreateBranchOfficeDto : ErrorDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
