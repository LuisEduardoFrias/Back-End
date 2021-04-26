using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
//
using ArsAfiliados.Service.SettingsStrings;
//

namespace ArsAfiliados.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;

                setupAction.ReturnHttpNotAcceptable = true;

                var jsonOutputFormatter = setupAction.OutputFormatters.OfType<SystemTextJsonOutputFormatter>().FirstOrDefault();

                if (jsonOutputFormatter != null)
                {
                    //plan
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.get.plans+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.get.search.plan+json");

                    //affilliate
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.get.affiliates+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.get.seach.affiliate+json");
                }

                var jsonInputFormatter = setupAction.InputFormatters.OfType<SystemTextJsonInputFormatter>().FirstOrDefault();

                if (jsonInputFormatter != null)
                {
                    //plan
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.create.plan+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.update.plan+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application.vnd.arsaffiliate.changestatus.plan+json");

                    //affilliate
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.create.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.update.amonunt.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.update.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("pplication/vnd.arsaffiliate.changestatus.affiliate+json");
                }

            });

            services.AddCors(setupAction =>
            {
                setupAction.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(SettingsStrings.Getinstance().OneOriginWeb)
                    .WithHeaders(new string[] { "Accept", "Content-Type" })
                    .WithMethods(new string[]{ "HttpPost", "HttpGet", "HttpPut", "HttpPatch"});
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

            app.UseMvc();
        }
    }
}
