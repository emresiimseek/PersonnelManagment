using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PersonnelManagement.DataAccsess;
using FrameworkCore.Concrate;
using PersonnelManagement.DataAccsess.Concrate;
using PersonnelManagement.Business.Concrate;
using PersonnelManagement.Business.Abstract;
using FrameworkCore.Utilities.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using PersonnelManagement.EntityFramework.Concrate;
using PersonnelManagement.Business.ValidationRules.FluentValidation;
using PersonnelManagement.EntityFramework.Concrate.DTOs;
using PersonnelManagement.WebAPI.Filters;

namespace PersonnelManagement.WebAPI
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
            services.AddScoped<DbContext, MyContext>();
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepositoryBase<>));
            services.AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository));
            services.AddScoped(typeof(IDepartmentService), typeof(DepartmentManager));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IAutoMapperBase), typeof(AutoMapperHelper));
            services.AddScoped<IsExistDepartmentFilter>();

            services.AddControllers().AddNewtonsoftJson(option =>
            option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddScoped<DepartmentManager>();
          
            
            //Fluent Validation Configurations
            services.AddMvc(setup => {
                //...mvc setup...
            }).AddFluentValidation();
            services.AddTransient<IValidator<DepartmentDto>, DepartmentValidator>();
            services.AddTransient<IValidator<UpdateDepartmentDto>, UpdateDepartmentValidator>();
            //services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DepartmentValidator>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddDbContext<MyContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString(), o =>
                 {
                     o.MigrationsAssembly("PersonnelManagement.DataAccsess");
                 });
            });
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
