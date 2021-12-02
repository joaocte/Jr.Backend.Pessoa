using Jr.Backend.Pessoa.Application.DependencyInjection;
using Jr.Backend.Pessoa.Infrastructure.DependencyInjection;
using Jror.Backend.Libs.Api.DependencyInjection;
using Jror.Backend.Libs.API.Abstractions;
using Jror.Backend.Libs.API.Abstractions.Interface;
using Jror.Backend.Libs.Framework.DependencyInjection;
using Jror.Backend.Libs.Security.Abstractions.Infrastructure.Interfaces;
using Jror.Backend.Libs.Security.DependencyInjection;
using Jror.Backend.Libs.Security.Infrastructure;
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
        private readonly IJrorApiOption jrApiOption;
        private readonly ISecurityConfiguration serSecurityConfiguration;

        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrorApiOption
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
            services.AddServiceDependencyJrorApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyApplication(Configuration);
            services.AddServiceDependencyInfrastructure(Configuration);
            services.AddServiceDependencyJrorFramework();
            services.AddServiceDependencyJrorSecurityApiUsingCustomValidate(() => serSecurityConfiguration);
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrorApiSwaggerSecurity(env, () => jrApiOption);
            //app.UseSecurity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}