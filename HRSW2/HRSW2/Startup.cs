using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HRSW2.AuthorizationRequirement;
using HRSW2.DatabaseContext;
using HRSW2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace HRSW2
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
        );

            services.AddDbContext<HrDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("MvcMovieContext")));

            // Cookie Auth
            services.ConfigureApplicationCookie(config =>
            {
                config.Cookie.Name = "ClientCookie";
                config.LoginPath = "/Home/Login";
            });

            //services.AddAuthentication("CookieAuth")
            //  .AddCookie("CookieAuth", config =>
            //  {
            //      config.Cookie.Name = "Bien";
            //      config.LoginPath = "/Home/Login";

            //  });

            services.AddIdentity<AppUser, AppRole>(config =>
            {
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;
                config.Password.RequiredLength = 2;
                config.Password.RequiredUniqueChars = 0;
                config.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<HrDbContext>()
                .AddDefaultTokenProviders();

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ClientRole",
            //         policy => policy.RequireRole("client"));
            //});

          

            //services.AddAuthorization(config =>
            //{

            //    config.AddPolicy("Admin", policyBuilder =>
            //    {
            //        policyBuilder.AddRequirements(new CustomRequireClaim(ClaimTypes.Role));
            //    });

            //});
            services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
