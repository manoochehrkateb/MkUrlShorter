using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MkUrlShorter.Core.ApplicationServices.UrlShorters;
using MkUrlShorter.Core.Domain.UrlShorters.Services;
using MkUrlShorter.Infra.Data.SqlServer;
using MkUrlShorter.Infra.Data.SqlServer.Contracts;
using MkUrlShorter.Infra.Data.SqlServer.Implements;

namespace MkUrlShorter.EndPoints.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<MkUrlShorterDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddControllers();
            //services.AddNewtonsoftJson();

            services.AddScoped<IUrlShorterService, UrlShorterService>();
            services.AddScoped<IUrlShorterRepository, UrlShorterRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MkUrShorter", Version = "v1" });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Advertisment API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
