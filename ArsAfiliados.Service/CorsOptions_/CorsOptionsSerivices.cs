using System;

namespace ArsAfiliados.Service.CorsOptions_
{
    public static class CorsOptionsSerivices
    {
        public static  Action<Microsoft.AspNetCore.Cors.Infrastructure.CorsOptions> setupAction = (setupAction) =>
        {
            setupAction.AddDefaultPolicy(policy =>
            {
                policy
                //.WithOrigins(new string[] { SettingsStrings.Getinstance().OneOriginWeb })
                .AllowAnyOrigin()
                .WithHeaders(new string[] { "Accept", "Content-Type" })
                .WithMethods(new string[] { "HttpPost", "HttpGet", "HttpPut", "HttpPatch" });

                //'Access-Control-Allow-Origin', '*'
                //'Access-Control-Allow-Methods', 'GET,POST,OPTIONS,DELETE,PUT'

            });
        };
    }
}
