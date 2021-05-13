using ArsAffiliate.Domain.Dtos.BranchOffice;

namespace ArsAffiliate.Domain.Dtos.Service
{
    public class ShowServiceDto : UpdateServiceDto
    {
        public ShowBranchOfficeDto BranchOffice { get; set; }
    }
}
