using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LXP.api.DbContexts;
using LXP.api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;

namespace LXP.api
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
            services.AddControllers(configure:setup => {
                setup.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson(setup => {
                setup.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }).AddXmlDataContractSerializerFormatters();
            //register AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //every hppt request will build a new service.
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddDbContext<RoutineDbContext>(optionsAction: options =>
            {
                options.UseSqlite(connectionString: "Data Source=LXP.db");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Add("indexl.html");    //将index.html改为需要默认起始页的文件名.
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
