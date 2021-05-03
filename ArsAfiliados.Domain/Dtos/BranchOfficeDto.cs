using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArsAfiliados.Domain.Dtos
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

    public class UpdateBranchOfficeDto : CreateBranchOfficeDto
    {
        public int Id { get; set; }
    }

    public class ShowBranchOfficeDto : UpdateBranchOfficeDto
    {
        public ICollection<ShowServiceDto> Services { get; set; }
    }
}
