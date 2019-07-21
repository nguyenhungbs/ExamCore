using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Exam.CoreData;
using Exam.CoreData.Repository.Common;
using Exam.CoreData.Repository.Common.Implement;
using Exam.Services.AccountFacade;
using Exam.Services.AccountFacade.Implement;
using Exam.Services.CategoryFacade;
using Exam.Services.CategoryFacade.Implement;
using Exam.Services.ProductFacade;
using Exam.Services.ProductFacade.Implement;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvcCore.Helpers;
using MvcCore.Helpers.Sessions;
using Serilog;
using Services.DepartmentFacade;
using Services.DepartmentFacade.Implement;
using Services.PatientFacade;
using Services.PatientFacade.Implement;
using Services.UserFacade;
using Services.UserFacade.Implement;

namespace MvcCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(Configuration)
                        .Enrich.FromLogContext()
                        .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDataProtection()
                    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Users\hung\AppData\Local\ASP.NET\DataProtection-Keys"));
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ExamDBContext>(
             option => option
                         //.UseLazyLoadingProxies()
                         .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IProductService, ProductService>();


            // Add MVC services to the services container.
            services.AddMvc(config =>
            {
                config.Filters.Add(typeof(GlobalExceptionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISessionHelper, SessionHelper>();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("AllowAll",
            //        builder =>
            //        {
            //            builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials();
            //        });
            //});

            //services.Configure<MvcOptions>(options => {
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAntiforgery antiforgery)
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


            app.UseMvc(routes =>
            {
                //Register routes for Client
                routes.MapRoute(
                name: "default",
                template: "{controller=Test}/{action=Index}/{id?}");

                //Register routes for Admin
                routes.MapRoute(
                name: "Admin",
                template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
            });
            //app.UseCors("AllowAll");
        }
    }
}
