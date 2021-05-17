using System;

namespace ArsAffiliate.Domain.Dtos.BranchOffice
{
    public class UpdateBranchOfficeDto : CreateBranchOfficeDto
    {
        public Guid Id { get; set; }
    }
}
