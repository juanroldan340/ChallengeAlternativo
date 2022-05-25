using ChallengeAlternativo.Data;
using ChallengeAlternativo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace ChallengeAlternativo
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
            
            services.AddDbContext<GeographicIconsDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddCors(options =>
            {
                options.AddPolicy(name: "GeoIconsAPI",
                                  policy =>
                                  {
                                      policy.WithOrigins("https://localhost:5001",
                                                          "https://localhost:5000");
                                  });
            });

            services.AddRouting(routing => routing.LowercaseUrls = true);

            services.AddControllers();

            services.AddScoped<IGeographicIconsRepository, GeographicIconsRepository>();

            services.AddScoped<ICitiesRepository, CitiesRepository>();

            services.AddScoped<IContinentRepository, ContinentRepository>();

            AddSwagger(services);

        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Geographic Icons {groupName}",
                    Version = groupName,
                    Description = "Geographic Icons API"
                });

                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Geographic Icons V1"));
            }

            app.UseHttpsRedirection();
            
            app.UseCors("GeoIconsAPI");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
