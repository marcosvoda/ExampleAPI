using AutoMapper;
using ExampleAPI.Api.UserManager.Db;
using ExampleAPI.Api.UserManager.Interfaces;
using ExampleAPI.Api.UserManager.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ExampleAPI.Api.UserManager
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

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IProvinciasService, ProvinciasService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<AuthenticationContext>(options =>
            {
                options.UseInMemoryDatabase("UsersAuthentication");
            });

            services.AddHttpClient("ProvinciasService", config =>
            {
                config.BaseAddress = new Uri(Configuration["Services:Provincias"]);
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
