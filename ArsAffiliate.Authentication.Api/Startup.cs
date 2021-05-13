using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Service.SettingsStrings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;


namespace ArsAffiliate.Authentication.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;

                setupAction.ReturnHttpNotAcceptable = true;

                var jsonInputFormatter = setupAction.InputFormatters.OfType<SystemTextJsonInputFormatter>().FirstOrDefault();

                jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.loign+json");
                jsonInputFormatter.SupportedMediaTypes.Add("aapplication/vnd.arsaffiliate.createuser+json");

            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<PersistencsDataContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SettingsStrings.Getinstance().KeyJwt)),
                       ClockSkew = TimeSpan.Zero
                   };
               });

            services.AddCors(setupAction => setupAction.AddPolicy("policy", policy =>
            policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSwaggerGen(sa => sa.SwaggerDoc("Documentacion Api Authentication", new OpenApiInfo()
            {
                Version = "V1.0",
                Title = "Api Authentication"
            }));

        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseSwaggerUI();

            app.UseCors();

            app.UseMvc();
        }
    }
}