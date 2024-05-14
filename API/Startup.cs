using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using Domain.Repositories;
using Infastructure.Repositories;
using Infastructure.DbContexts;
using Service.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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
            #region CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllDomains", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            #endregion

            services.AddControllers();
            #region Default Services
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer
           (Configuration.GetConnectionString("Default"), x => x.MigrationsAssembly("Infastructure")));
 

            services.AddTransient<IProductService, ProductService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("Product", new OpenApiInfo { Title = "Product Api", Version = "v1" });
            });
            #endregion

  
            services.AddMvc();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("AllowAllDomains");
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/Product/swagger.json", "Product Api");
                c.RoutePrefix = string.Empty;

            });

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
