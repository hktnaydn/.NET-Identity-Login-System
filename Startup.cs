using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using aspnetcoreıdentyegitim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using aspnetcoreıdentyegitim.CustomValidation;

namespace aspnetcoreıdentyegitim
{
    public class Startup
    {


        public IConfiguration configuration { get; }


        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppIdentityContext>(opts =>
            {
                opts.UseSqlServer(configuration["ConnectionString:DefaultConnectionString"]);
            }
             );



            CookieBuilder cookieBuilder = new CookieBuilder();
            cookieBuilder.Name = "MyBlog";
            cookieBuilder.HttpOnly = false;
        //    cookieBuilder.Expiration = System.TimeSpan.FromDays(60);
            
            cookieBuilder.SameSite = SameSiteMode.Lax;
            cookieBuilder.SecurePolicy = CookieSecurePolicy.SameAsRequest;

            services.ConfigureApplicationCookie(opts =>
            {
                opts.LoginPath = new PathString("/Home/Login");
                opts.Cookie = cookieBuilder;
                opts.SlidingExpiration = true;
            }
            );
            services.AddIdentity<AppUser, AppRole>(opts=>
            {

                opts.User.RequireUniqueEmail = true;
                opts.User.AllowedUserNameCharacters = "qwertyuıopğüişlkjhgfdsazxcvbnmöçQWERTYUIOPLKJHGFDSAZXCVBNM123456789-._";

                opts.Password.RequiredLength = 4;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
            }
            ).AddPasswordValidator<CustomPasswordValidator>().AddUserValidator<CustomUserValidator>().AddEntityFrameworkStores < AppIdentityContext >();




            services.AddMvc(options => options.EnableEndpointRouting = false);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();

        }
    }
}
