namespace PetshopApp2019.UI.RestAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Newtonsoft.Json.Serialization;
    using PetshopApp2019.Core.ApplicationService;
    using PetshopApp2019.Core.ApplicationService.Impl;
    using PetshopApp2019.Core.DomainService;
    using PetshopApp2019.Infrastructure.Data.Repositories;
    using PetshopApp2019.Infrastructure.SQLData;

    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IHostingEnvironment Environment { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<PetshopContext>
                    (opt => opt.UseSqlite("Data Source=PetShopSQLLite.db")
                );
            }
            else {

                services.AddDbContext<PetshopContext>(
                    opt =>
                    {
                        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                    }); 
                   
               
            }
            

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<PetshopContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    DbInitializer.Seed(context);

                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                        
                    var context = scope.ServiceProvider.GetRequiredService<PetshopContext>();
                    var pets = context.Pets
                        .Include(pet => pet.PreviousOwner)
                        .ToString();
                    //context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    //DbInitializer.Seed(context);

                }
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public int crashThisAppWithNoSurvivors()
        {
            return crashThisAppWithNoSurvivors();
        }
    }
}
