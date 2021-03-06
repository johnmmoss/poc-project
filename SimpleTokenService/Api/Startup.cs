﻿using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SimpleTokenService.Data;
using SimpleTokenService.Data.Entities;
using SimpleTokenService.Domain;
using SimpleTokenService.Domain.Core;
using SimpleTokenService.Domain.Interfaces;
using SimpleTokenService.Domain.Settings;

namespace SimpleTokenService.Api
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           
            // TODO:- Fix this up to use log4net
            services.AddLogging(config => config.AddConsole().AddDebug());

            var connectionString = "Server=(local)\\sqlexpress;Initial Catalog=SimpleTokenService;Persist Security Info=False; integrated security=True";
            services.AddDbContext<TokenContext>(o => o.UseSqlServer(connectionString));
            services.AddIdentity<User, Role>()
              .AddUserManager<UserManager<User>>()
              .AddDefaultUI(UIFramework.Bootstrap4)
              .AddEntityFrameworkStores<TokenContext>();

            var jwtSettings = GetJwtSettings();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Key)),
                   ValidateIssuer = true,
                   ValidIssuer = jwtSettings.Issuer,
                   ValidateAudience = true,
                   ValidAudience = jwtSettings.Audience,
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.FromMinutes(jwtSettings.MinutesToExpiration)
               };
           });

            services.AddSingleton(jwtSettings);
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStatementService, StatementService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public JwtSettings GetJwtSettings()
        {
            var settings = new JwtSettings();
            settings.Key = Configuration["JwtSettings:key"];
            settings.Audience= Configuration["JwtSettings:audience"];
            settings.Issuer= Configuration["JwtSettings:issuer"];
            settings.MinutesToExpiration = Convert.ToInt32(Configuration["JwtSettings:minutesToExpiration"]);

            return settings;
        }
    }
}
