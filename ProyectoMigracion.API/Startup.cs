using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ProyectoMigracion.Core.Interfaces;
using ProyectoMigracion.Core.Services;
using ProyectoMigracion.Infrastructure.Data;
using ProyectoMigracion.Infrastructure.Filters;
using ProyectoMigracion.Infrastructure.Repositories;

namespace ProyectoMigracion.API
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

            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>())
            .AddNewtonsoftJson(options =>
            {
               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProyectoMigracion.API", Version = "v1" });
            });

            //Inyeccion del DbContext con el ConnectionString
            services.AddDbContext<ProyectoMigracionContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ProyectoMigracionConnectionString"));
            });

            //Filtros de validacion personalizados
            services.AddMvc(options =>
            {
                options.Filters.Add<ValidationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProyectoMigracion.API v1"));
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
