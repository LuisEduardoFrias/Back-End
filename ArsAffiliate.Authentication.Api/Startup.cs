using ArsAffiliate.Domain.Entitys;
using ArsAffiliate.Persistence.Data;
using ArsAffiliate.Service.AutoMapper;
using ArsAffiliate.Service.SettingsStrings;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;
using System.Text;


namespace ArsAffiliate.Api.Authentication
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

            services.AddSingleton<IMapper>(new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(typeof(Configurations));
            }).CreateMapper());

            services.AddDbContext<PersistencsDataContext>(option => 
            option.UseSqlServer( SettingsStrings.ConnectionString, migrationsAssembly => 
            migrationsAssembly.MigrationsAssembly("ArsAffiliate.Persistence")));

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<PersistencsDataContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddMvc(setupAction =>
            {
                setupAction.EnableEndpointRouting = false;

                setupAction.ReturnHttpNotAcceptable = true;

                var jsonInputFormatter = setupAction.InputFormatters.OfType<SystemTextJsonInputFormatter>().FirstOrDefault();

                jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.loign+json");
                jsonInputFormatter.SupportedMediaTypes.Add("application/vnd.arsaffiliate.createuser+json");

            });


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SettingsStrings.KeyJwt)),
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