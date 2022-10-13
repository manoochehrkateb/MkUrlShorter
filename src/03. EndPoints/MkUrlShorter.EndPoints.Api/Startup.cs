using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MkUrlShorter.Core.ApplicationServices.WeatherForecasts;
using MkUrlShorter.Core.Domain.WeatherForecasts.Services;
using MkUrlShorter.Infra.Data.SqlServer;

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
            services.AddDbContextPool<MkUrlShorterDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("")));
            services.AddControllers();
            //services.AddNewtonsoftJson();

            services.AddScoped<IRandomForecastsGenerator, RandomForecastsGenerator>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
