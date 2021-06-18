using BAL.Service;
using DAL.Data;
using DAL.Interface;
using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.Sqlite;
using AspNetCoreWebApiService2021.DAL;
using BAL.Interfaces;

namespace AspNetCoreAPIWebService
{
    public class Startup
    {      

        public Startup()
        {
      
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("name=ConnectionStrings:DefaultConnection"));
            services.AddControllers();
            services.AddHttpClient();        
            services.AddTransient<IPopulationService, PopulationService>();
            services.AddTransient<IHouseholdsService, HouseholdsService>();
            services.AddTransient<IRepository<Actuals>, Repository<Actuals>>();
            services.AddTransient<IRepository<Estimates>, Repository<Estimates>>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreWebApiService", Version = "v1" });
            });
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreWebApiService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
