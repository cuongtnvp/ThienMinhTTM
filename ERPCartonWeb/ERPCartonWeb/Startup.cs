﻿using AutoMapper;
using ERPCartonWeb.Application.Implementations;
using ERPCartonWeb.Application.Interfaces;
using ERPCartonWeb.Data.EF;
using ERPCartonWeb.Data.EF.Repositories;
using ERPCartonWeb.Data.Entities;
using ERPCartonWeb.Data.IRepositories;
using ERPCartonWeb.Data.Repositories;
using ERPCartonWeb.Helpers;
using ERPCartonWeb.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Linq;

namespace ERPCartonWeb
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                o => o.MigrationsAssembly("ERPCartonWeb.Data.EF")));

            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.AddAutoMapper();
            // Add application services.
            services.AddScoped<UserManager<AppUser>, UserManager<AppUser>>();
            services.AddScoped<RoleManager<AppRole>, RoleManager<AppRole>>();

            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddTransient<DbInitializer>();
            //Repositories

            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            //Services
            services.AddTransient<IProductCategoryService, ProductCategoryService>();
            services.AddTransient<IFunctionService, FunctionService>();
            services.AddScoped<IUserClaimsPrincipalFactory<AppUser>, CustomClaimsPrincipalFactory>();

            services.AddMvc().AddJsonOptions(options=>options.SerializerSettings.ContractResolver=new DefaultContractResolver());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/cuong-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(name: "areaRoute",
                    template: "{area:exists}/{controller=Login}/{action=Index}/{id?}");
            });
            // For wwwroot directory
            //app.UseStaticFiles();

            //// Add support for node_modules but only during development **temporary**
            //if (env.IsDevelopment())
            //{
            //    app.UseStaticFiles(new StaticFileOptions()
            //    {
            //        FileProvider = new PhysicalFileProvider(
            //          Path.Combine(Directory.GetCurrentDirectory(), @"node_modules/")),
            //        RequestPath = new PathString("/vendor")
            //    });
            //}

        }
    }
}
