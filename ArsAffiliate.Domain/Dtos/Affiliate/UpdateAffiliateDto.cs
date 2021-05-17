using System;

namespace ArsAffiliate.Domain.Dtos.Affiliate
{
    public class UpdateAffiliateDto : CreateAffiliateDto
    {
        public Guid Id { get; set; }
    }
}
