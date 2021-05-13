using ArsAffiliate.Domain.Dtos.Service;
using System.Collections.Generic;

namespace ArsAffiliate.Domain.Dtos.MedicalBill
{
    public class ShowMedicalBillDto : UpdateMedicalBillDto
    {
        public ICollection<ShowServiceDto> Services { get; set; }
    }
}
