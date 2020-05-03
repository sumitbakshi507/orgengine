using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using OrgLive.Domain.Core.Bus;
using OrgLive.Infra.IoC;
using OrgLive.QuotingEngine.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrgLive.QuotingEngine.Domain.Events;
using OrgLive.QuotingEngine.Domain.EventHandlers;
using System.Reflection;

namespace OrgLive.QuotingEngine.Api
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
            services.AddDbContext<QuoteDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("QuoteDbConnection"));
            });

            RefreshDBSchema();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Quote Microservice", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));

            RegisterServices(services);
            services.AddControllers();
        }

        private void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        private void RefreshDBSchema() 
        {
            var assemblyName = "OrgLive.QuotingEngine.Domain";
            var nameSpace = "OrgLive.QuotingEngine.Domain.Models";

            var asm = Assembly.Load(assemblyName);
            var dbObjects = asm.GetTypes().Where(p =>
                 p.Namespace == nameSpace
            ).ToList();

            Console.WriteLine(dbObjects);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Quote Microservice V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            //eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
            eventBus.Subscribe<QuoteRequestCreatedEvent, QuoteRequestEventHandler>();
        }
    }
}
