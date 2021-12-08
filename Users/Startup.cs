using CRUD_BAL.Service;
using CRUD_DAL.Data;
using CRUD_DAL.Interface;
using CRUD_DAL.Models;
using CRUD_DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Users.Controllers;
//using Unity;
using static CRUD_DAL.Models.Persons;

namespace Users
{
    public class Startup
    {         
        private readonly IConfiguration _configuration;       

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
        }

        public void ConfigureContainer(IUnityContainer container)
        {
            container.RegisterType<IRepository<Person>, GenericRepository<Person>>();
            container.RegisterType<PersonDetailsController>();
            container.RegisterType<ApplicationDbContext>(new InjectionConstructor(new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(_configuration.GetConnectionString("DefaultConnection"))
                .Options));
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
