using System;
using _0_Framework.Application;
using _0_Framework.Application.Email;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dr.Application;
using dr.Application.Contract.User;
using dr.Domain.Entities.Role;
using dr.Domain.Entities.User;
using dr.Infrastracture;
using dr.Infrastracture.Repositories;
using Microsoft.EntityFrameworkCore;
using _0_Framework.Interfaces;
using dr.Application.Contract.Doctor;
using dr.Application.Contract.Recovery;
using dr.Domain.Entities.Doctor;
using dr.Domain.Entities.RecoveryCode;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace dr.Web
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
            services.AddDbContext<ApplicationDbContext>(x =>
                x.UseSqlServer(Configuration.GetConnectionString("dr_DB")));
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IRecoverCodeRepository, RecoverCodeRepository>();
            services.AddTransient<IRecoveryCodeApplication, RecoveryCodeApplication>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IDoctorApplication, DoctorApplication>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.Configure<CookiePolicyOptions>(options =>
            {
	            //this line does access to tempData work 
	            // options.CheckConsentNeeded = context => true;
	            options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
	            {
		            o.LoginPath = new PathString("/Login");
		            o.LogoutPath = new PathString("/Login");
		            o.AccessDeniedPath = new PathString("/Index");
		            o.ExpireTimeSpan = TimeSpan.FromDays(7);
	            });
			services.AddAuthorization(option =>
            {
                option.AddPolicy("Admin", policy =>
                {
                    policy.RequireRole(Roles.Doctor, Roles.Assistant);
                });
            });
            services.AddRazorPages(option =>
            {
                option.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
			app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
			app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
