using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.OpenApi.Models;
//
using ArsAfiliados.Service.CorsOptions_;
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
                    //plan ado.net
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.get.plans+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.get.search.plan+json");
                    //plan entity framework core
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.get.plans+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.get.search.plan+json");

                    //affilliate ado.net
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.get.affiliates+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.get.seach.affiliate+json");
                    //affilliate entity framework core
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.get.affiliates+json");
                    jsonOutputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.get.seach.affiliate+json");
                }

                var jsonInputFormatter = setupAction.InputFormatters.OfType<SystemTextJsonInputFormatter>().FirstOrDefault();

                if (jsonInputFormatter != null)
                {
                    //plan ado.net
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.create.plan+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.update.plan+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application.vnd.arsaffiliate.ado.changestatus.plan+json");
                    //plan entity framework core
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.create.plan+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.update.plan+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application.vnd.arsaffiliate.efc.changestatus.plan+json");

                    //affilliate ado.net
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.create.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.update.amonunt.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.update.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.ado.changestatus.affiliate+json");
                    //affilliate entity framework core
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.create.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.update.amonunt.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.update.affiliate+json");
                    jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.efc.changestatus.affiliate+json");
                }

            });

            services.AddCors(setupA => CorsOptionsSerivices.setupAction(setupA));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Documentacion Api Ars Afilidos", new OpenApiInfo 
                { Title = "API Ars Afiliados", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseSwaggerUI();

            app.UseCors();

            app.UseMvc();
        }
    }
}
