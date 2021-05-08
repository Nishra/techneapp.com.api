using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using techneapp.com.application.Interface;
using techneapp.com.application.Service;
using techneapp.com.infrastructure;
using techneapp.com.infrastructure.Interface;
using techneapp.com.infrastructure.Service;

namespace techneapp.com.api
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
            services.AddDbContext<TechneAppDbContext>
                                (o => o.UseNpgsql(Configuration.
                                GetConnectionString("DeveloperDatabase")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechneApp API", Version = "v1" });
            });

            services.AddTransient<ITechneAppDbContext,TechneAppDbContext>();

            services.AddScoped<IDepartmentApplicationService, DepartmentApplicationService>();
            services.AddScoped<IEmployeeApplicationService, EmployeeApplicationService>();

            services.AddScoped<IDepartmentInfrastructureService, DepartmentInfrastructureService>();
            services.AddScoped<IEmployeeInfrastructureService, EmployeeInfrastructureService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechneApp API V1");
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
