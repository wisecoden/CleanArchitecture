﻿using CleanArch.Infra.IoC;
using CleanArch.MVC.MappingConfig;
using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    namespace CleanArch.MVC
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
                services.AddInfrastructure(Configuration);
                services.AddControllersWithViews();
                services.AddAutoMapperConfiguration();
                services.AddRazorPages();
            }
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

                else
                {
                    app.UseExceptionHandler("/Home/Error");
                    app.UseHsts();
                }

                app.UseHttpsRedirection(); 
                app.UseStaticFiles();        
                app.UseRouting();
                app.UseAuthentication();
                app.UseAuthorization();
                 
       
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                    endpoints.MapRazorPages();
                });
            }
        }
    }

