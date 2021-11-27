using Jr.Backend.Libs.API.Abstractions;
using Jr.Backend.Libs.API.DependencyInjection;
using Jr.Backend.Libs.Framework.DependencyInjection;
using Jr.Backend.Libs.Security.Abstractions.Infrastructure.Interfaces;
using Jr.Backend.Libs.Security.DependencyInjection;
using Jr.Backend.Libs.Security.Infrastructure;
using Jr.Backend.Libs.Security.Middleware;
using Jr.Backend.Pessoa.Application.DependencyInjection;
using Jr.Backend.Pessoa.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jr.Backend.Pessoa.Api
{
    /// <inheritdoc/>
    public class Startup
    {
        private readonly IJrApiOption jrApiOption;
        private readonly ISecurityConfiguration serSecurityConfiguration;

        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrApiOption
            {
                Title = "Jr.Backend.Pessoa.Api",
                Description = "Api de Cadastro de Pessoas",
                Email = "joaocte@gmail.com",
                Uri = "https://github.com/joaocte/Jr.Backend.Pessoa",
            };
            serSecurityConfiguration =
                new SecurityConfiguration("mongodb://localhost:27017/?authSource=admin", "JrTenant");
        }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddServiceDependencyJrApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyApplication(Configuration);
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrFramework();
            services.AddServiceDependencyJrSecurityApiUsingCustomValidate(() => serSecurityConfiguration);
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrApiSwaggerSecurity(env, () => jrApiOption);
            app.UseSecurity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}