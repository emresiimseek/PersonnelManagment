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
using FrameworkCore.Helpers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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


            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped(typeof(IPersonnelRepository), typeof(PersonnelRepository));
            services.AddScoped(typeof(IPersonnelService), typeof(PersonnelManager));

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
