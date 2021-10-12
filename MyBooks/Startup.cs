using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyBooks.Data;
using MyBooks.Data.AuthorsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyBooks.Data.BooksRepository;
using MyBooks.Data.OrderBooksRepository;

namespace MyBooks
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
            
            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<MyBooksDBContext>(options => options.UseSqlServer(connString));
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IBooksRepository, BooksRepository>();
            services.AddScoped<IOrderBooksRepository, OrderBooksRepository>();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();

            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.ConsentCookie.IsEssential = true;
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.IsEssential = true;
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.None;

                    options.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.LoginPath = "/account/google-login";

                })
                .AddGoogle(options =>
                {
                    options.ClientId = "177635740346-egfevtm6uknr8bergpkql8hedgotio4u.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    // options.CallbackPath= "/google-auth-callback"; ;
                });
            services.AddRazorPages();
            
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
