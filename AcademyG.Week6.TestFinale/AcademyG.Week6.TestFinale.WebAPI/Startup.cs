using AcademyG.Week6.TestFinale.Core;
using AcademyG.Week6.TestFinale.Core.EF;
using AcademyG.Week6.TestFinale.Core.EF.Repositories;
using AcademyG.Week6.TestFinale.Core.Interfaces;
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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AcademyG.Week6.TestFinale.WebAPI
{
    public class Startup
    {
        public readonly string ApplicationName =
            Assembly.GetEntryAssembly().GetName().Name;
        public readonly string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddNewtonsoftJson(options => {
                 options.SerializerSettings.ReferenceLoopHandling =
                     Newtonsoft.Json.ReferenceLoopHandling.Ignore;
             });

            //Configurazione Dependency Injection
            services.AddTransient<IGestionaleBL, GestionaleBL>();
            services.AddTransient<IClienteRepository, EFClienteRepository>();
            services.AddTransient<IOrdineRepository, EFOrdineRepository>();

            //Configurazione EFCore
            services.AddDbContext<GestionaleContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("AcademyGWS"));
            });

            //Configurazione Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion
                });
                string file = $"{typeof(Startup).Assembly.GetName().Name}.xml";
                string xmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint(
                        "v1/swagger.json",
                        $"{ApplicationName} {ApplicationVersion}"
                    );
                });
            }

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
