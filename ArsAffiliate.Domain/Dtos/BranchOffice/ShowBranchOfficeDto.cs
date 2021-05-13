using ArsAffiliate.Domain.Dtos.Service;
using System.Collections.Generic;

namespace ArsAffiliate.Domain.Dtos.BranchOffice
{
    public class ShowBranchOfficeDto : UpdateBranchOfficeDto
    {
        public ICollection<ShowServiceDto> Services { get; set; }
    }
}
