using ArsAffiliate.Domain.Dtos;
using ArsAffiliate.Domain.Dtos.Affiliate;
using ArsAffiliate.Domain.Dtos.Plan;
using ArsAffiliate.Domain.Entitys;
using AutoMapper;

namespace ArsAffiliate.Service.AutoMapper
{
    public class Configurations : Profile
    {
        public Configurations()
        {
            CreateMap<CreateAffiliateDto, Affiliate>();
            CreateMap<UpdateAffiliateDto, Affiliate>();
            CreateMap<Affiliate, ShowAffiliateDto>();

            CreateMap<CreatePlanDto, Plan>();
            CreateMap<UpdatePlanDto, Plan>();
            CreateMap<Plan, ShowPlanDto>();

            CreateMap<RequestAuthentication, RequestAuthenticationDto>();
            CreateMap<RequestAuthenticationDto, RequestAuthentication>();
        }
    }
}
