using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Exam.Api.Helpers;
using Exam.CoreData;
using Exam.CoreData.Repository.Common;
using Exam.CoreData.Repository.Common.Implement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Services.DepartmentFacade;
using Services.DepartmentFacade.Implement;
using Services.PatientFacade;
using Services.PatientFacade.Implement;
using Services.UserFacade;
using Services.UserFacade.Implement;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ExamProject
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
            // Add framework services.
            services.AddMvc(config=> {
                config.Filters.Add(typeof(GlobalExceptionFilter));
            });
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Info { Title = "ExamProject v1", Version = "V1" });
                config.IncludeXmlComments(string.Format("{0}\\Exam.Api.xml", AppDomain.CurrentDomain.BaseDirectory));
                config.IncludeXmlComments(string.Format("{0}\\Exam.CoreData.xml", AppDomain.CurrentDomain.BaseDirectory));

                //var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
                //var commentsFile = Path.Combine(baseDirectory, "bin", commentsFileName);

                //config.IncludeXmlComments(commentsFile);
            });
            services.AddDbContext<ExamDBContext>(
                option => option
                            .UseLazyLoadingProxies()
                            .UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPatientService, PatientService>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                    });
            });

            services.Configure<MvcOptions>(options => {
                options.Filters.Add(new CorsAuthorizationFilterFactory("AllowAll"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(config => {
                config.SwaggerEndpoint("v1/swagger.json", "ExamProject Api");
                config.DocExpansion(DocExpansion.None);
                config.ShowExtensions();
            });
            app.UseCors("AllowAll");
        }
    }
}
