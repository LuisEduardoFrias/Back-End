using AutoMapper;
//
using ArsAfiliados.Domain.Dtos;
using ArsAfiliados.Domain.Entitys;
//

namespace ArsAfiliados.Service.AutoMapper
{
    public class Configurations : Profile
    {
        public Configurations()
        {
            //afiliate
            CreateMap<CreateAffiliateDto, Affiliate>();
            CreateMap<UpdateAffiliateDto, Affiliate>();
            CreateMap<Affiliate, ShowAffiliateDto>();


            //plan
            CreateMap<CreatePlanDto, Plan>();
            CreateMap<UpdatePlanDto, Plan>();
            CreateMap<Plan, ShowPlanDto>();

            //authentication
            CreateMap<RequestAuthentication, RequestAuthenticationDto>();
        }
    }
}
