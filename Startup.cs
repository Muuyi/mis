﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text;
using mis.Models;
using AutoMapper;

namespace mis
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
             services.AddAutoMapper(typeof(Startup));
             //CONFIGURING AUTOMAPPER
            //  var config = new AutoMapper.MapperConfiguration(cfg =>
            //     {
            //         cfg.AddProfile(new OrderDataMappingProfile ());
            //     });
            //     var mapper = config.CreateMapper();
            //     _serviceCollection.AddSingleton(mapper);
            //INJECT APP SETTINGS
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            //COMPATIBILTY
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //DATABASE CONNECTION
            // services.AddDbContext<DatabaseContext>(options => options.UseMySql("server=localhost;port=3306;database=mis;user=root;password="));
            services.AddDbContext<AuthenticationContext>(options => options.UseMySql("server=localhost;port=3306;database=mis;user=root;password="));
            //ADD IDENTITY USER
            services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<AuthenticationContext>();
            //APPLICATION USER
            // services.Configure<IdentityOptions>(options => {
            //     options.Password.RequireDigit = false;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireLowercase = false;
            //     options.Password.RequireUppercase = false;
            //     options.Password.RequiredLength = 4; 
            // });
            //ENABLING CORS-CROSS ORIGIN RESOURCE SHARING
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder=>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            //Authentication key
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            //ADD JWT AUTHENTICATION
            services.AddAuthentication(x=>{
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                // .AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx,next)=>{
                await next();
                if(ctx.Response.StatusCode == 204){
                    ctx.Response.ContentLength = 0;
                }
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //USE AUTHENTICATION
            app.UseAuthentication();
            // app.UseCors(options => options.WithOrigins("http://localhost:4200"));
            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
