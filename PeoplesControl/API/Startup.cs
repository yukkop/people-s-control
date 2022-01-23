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
            services.AddScoped<IAuthenticationQuery, AuthenticationQuery>();

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

            services.AddScoped<IUserQuery, UserQuery>();

            AutoMapper.IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CityProfile>();
                cfg.AddProfile<DistrictProfile>();
                cfg.AddProfile<AvatarProfile>();
                cfg.AddProfile<RoleProfile>();
                cfg.AddProfile<ActionMetaProfile>();
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
