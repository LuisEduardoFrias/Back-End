using System;

namespace ArsAffiliate.Service.CorsOptions_
{
    public static class CorsOptionsSerivices
    {
        public static  Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions> setupAction = (setupAction) =>
        {
            setupAction.AddDefaultPolicy(policy =>
            {
                policy
                .WithOrigins("http://localhost:4200")
                .WithHeaders("Accept", "Content-Type", "Access-Control-Allow-Methods")
                .WithMethods( "GET", "POST", "PUT", "PATCH");
            });
        };
    }
}
