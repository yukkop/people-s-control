using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Repositories;
using Logic.Queries;
using Logic.WriteServices;
using Logic.ReadServices;
using DataBase;
using AutoMapper;
using Logic.Profiles;
using Logic.WebEntities;
using Logic.Helpers;
using DataBase.Models;

namespace API
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
            services.AddControllers();

            services.AddSwaggerGen();

            services.AddDbContext<Context>(l => l.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IWebContext, Context>();

            services.AddScoped<IActionMetaRepository, ActionMetaRepository>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICityQuery, CityQuery>();
            services.AddScoped<ICityWriteService, CityWriteService>();
            services.AddScoped<ICityReadService, CityReadService>();

            services.AddScoped<IAvatarRepository, AvatarRepository>();
            services.AddScoped<IAvatarQuery, AvatarQuery>();
            services.AddScoped<IAvatarWriteService, AvatarWriteService>();
            services.AddScoped<IAvatarReadService, AvatarReadService>();

            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IDistrictQuery, DistrictQuery>();
            services.AddScoped<IDistrictWriteService, DistrictWriteService>();
            services.AddScoped<IDistrictReadService, DistrictReadService>();

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleQuery, RoleQuery>();
            services.AddScoped<IRoleWriteService, RoleWriteService>();
            services.AddScoped<IRoleReadService, RoleReadService>();


            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileQuery, UserProfileQuery>();
            services.AddScoped<IUserProfileWriteService, UserProfileWriteService>();
            services.AddScoped<IUserProfileReadService, UserProfileReadService>();

            services.AddScoped<IUserQuery, UserQuery>();

            services.AddScoped<IUserRoleQuery, UserRoleQuery>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            //reports
            services.AddScoped<IReportStatusRepository, ReportStatusRepository>();
            services.AddScoped<IReportStatusQuery, ReportStatusQuery>();
            services.AddScoped<IReportStatusWriteService, ReportStatusWriteService>();
            services.AddScoped<IReportStatusReadService, ReportStatusReadService>();

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportQuery, ReportQuery>();
            services.AddScoped<IReportWriteService, ReportWriteService>();
            services.AddScoped<IReportReadService, ReportReadService>();

            services.AddScoped<IReportViewRepository, ReportViewRepository>();
            services.AddScoped<IReportViewWriteService, ReportViewWriteService>();

            services.AddScoped<IReportByProblemCategoryRepository, ReportByProblemCategoryRepository>();
            services.AddScoped<IReportByProblemCategoryWriteService, ReportByProblemCategoryWriteService>();


            services.AddScoped<IMediaDataTypeRepository, MediaDataTypeRepository>();
            services.AddScoped<IMediaDataTypeQuery, MediaDataTypeQuery>();
            services.AddScoped<IMediaDataTypeWriteService, MediaDataTypeWriteService>();
            services.AddScoped<IMediaDataTypeReadService, MediaDataTypeReadService>();

            services.AddScoped<IProblemCategoryRepository, ProblemCategoryRepository>();
            services.AddScoped<IProblemCategoryQuery, ProblemCategoryQuery>();
            services.AddScoped<IProblemCategoryWriteService, ProblemCategoryWriteService>();
            services.AddScoped<IProblemCategoryReadService, ProblemCategoryReadService>();

            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IRegionQuery, RegionQuery>();
            services.AddScoped<IRegionReadService, RegionReadService>();
            services.AddScoped<IRegionWriteService, RegionWriteService>();

            AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ActionMetaProfile>();

                cfg.AddProfile<CityProfile>();
                cfg.AddProfile<DistrictProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<UserProfileProfile>();

                cfg.AddProfile<ReportStatusProfile>();
                cfg.AddProfile<ReportProfile>();
                cfg.AddProfile<MediaDataTypeProfile>();
                cfg.AddProfile<ProblemCategoryProfile>();

            });
            services.AddSingleton(config);
            services.AddScoped<IMapper, Mapper>();


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

            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1")
            );
        }
    }
}
