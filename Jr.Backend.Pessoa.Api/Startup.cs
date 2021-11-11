using FluentValidation.AspNetCore;
using Jr.Backend.Libs.Framework.DependencyInjection;
using Jr.Backend.Pessoa.Api.Swagger;
using Jr.Backend.Pessoa.Application.DependencyInjection;
using Jr.Backend.Pessoa.Domain.Validations;
using Jr.Backend.Pessoa.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jr.Backend.Pessoa.Api
{
    /// <inheritdoc/>
    public class Startup
    {
        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddApiVersioning(o =>
            {
                o.UseApiBehavior = false;
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);

                o.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("x-api-version"),
                    new UrlSegmentApiVersionReader());
            });
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            services.AddSwaggerGen();
            services.AddServiceDependencyApplication(Configuration);
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrFramework();

            services.AddMvc().AddFluentValidation(fvc =>
                            fvc.RegisterValidatorsFromAssemblyContaining<DocumentosValidacoes>());
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jr.Backend.Pessoa.Api v1"));
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