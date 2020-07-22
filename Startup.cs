using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityApp.Models;

namespace UniversityApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSession();
            services.AddDbContext<UserContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"])
                .UseLazyLoadingProxies());
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<UserContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                // * Lockout settings
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                // * Must require a unique email
                options.User.RequireUniqueEmail = true;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>{
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/LogOut";
                    options.Cookie.Name = "UniversityApp_Cookie";
                    options.Cookie.HttpOnly = false;
                    options.Cookie.SameSite = SameSiteMode.None;
                });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            var cookiePolicyOptions = new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = SameSiteMode.Strict
            };

            app.UseCookiePolicy(cookiePolicyOptions);
            // app.UseCookieAuthentication(new CookieAuthenticationOptions()
            // {
            // AuthenticationScheme = "Cookies",
            //     LoginPath = new PathString(""),
            //     AccessDeniedPath = new PathString(""),
            //     AutomaticAuthenticate = true,
            //     AutomaticChallenge = true,
            // });

            CreateRoles(serviceProvider).Wait();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            string[] roleNames = {"Admin", "Teacher", "Student"};

            foreach(string role in roleNames)
            {
                if(!await RoleManager.RoleExistsAsync(role))
                {
                    await RoleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var _admin = await UserManager.FindByEmailAsync("admin@admin.com");
            if (_admin == null)
            {
                var admin = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com"
                };

                var createAdmin = await UserManager.CreateAsync(admin, "Admin2019!");
                if (createAdmin.Succeeded)
                    await UserManager.AddToRoleAsync(admin, "Admin");
            }

            var _teacher = await UserManager.FindByEmailAsync("teacher@teacher.com");
            if (_teacher == null)
            {
                var teacher = new User
                {
                    UserName = "teacher@teacher.com",
                    Email = "teacher@teacher.com"
                };

                var createTeacher = await UserManager.CreateAsync(teacher, "Teacher2019!");
                if (createTeacher.Succeeded)
                    await UserManager.AddToRoleAsync(teacher, "Teacher");
            }
        }
    }
}
