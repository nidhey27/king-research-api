using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using MediatR;
using KingResearch.Repository.IRepository;
using KingResearch.Repository.Repository;
using KingResearch.Domain.Models;
using KingResearch.API.Middleware;

namespace KingResearch.API
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KingResearch.API", Version = "v1" });
            });

            var assembly = AppDomain.CurrentDomain.Load("KingResearch.Application");

            services.AddMediatR(assembly);
           
            services.AddDbContext<KingResearchDbContext>();

            services.AddScoped<IBusinesRepository<Domain.Models.Dmat>, BusinesRepository<Domain.Models.Dmat>>();
            services.AddScoped<IBusinesRepository<Domain.Models.Video>, BusinesRepository<Domain.Models.Video>>();
            services.AddScoped<IBusinesRepository<Domain.Models.Event>, BusinesRepository<Domain.Models.Event>>();
            services.AddScoped<IBusinesRepository<Domain.Models.Service>, BusinesRepository<Domain.Models.Service>>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KingResearch.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
