using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PerfectChannel.Data;
using PerfectChannel.Infrastructure.Repositories;
using PerfectChannel.WebApi.Extensions;

namespace PerfectChannel.WebApi
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
            services.AddCors();
            services.AddControllers();

            services.AddSwaggerDocumentation();

            services.AddSingleton<IDataContext, DataContext>();
            services.AddScoped<ITaskRepository, TaskRepository>();

            //ConfigureCors(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerDocumentation();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            var frontendServerUrl = Configuration.GetValue<string>("FrontendServerUrl");
            services.AddCors(options =>
                options.AddPolicy("AllowOrigin", builder =>
                    builder.WithOrigins(frontendServerUrl)
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );
        }
    }
}
