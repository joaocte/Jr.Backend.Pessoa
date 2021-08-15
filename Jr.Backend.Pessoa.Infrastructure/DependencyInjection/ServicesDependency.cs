using Jr.Backend.Pessoa.Domain;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Context;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Jr.Backend.Pessoa.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")?.ToLowerInvariant();
            services.AddScoped<IMongoContext>((p) =>
            {
                var config = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                                 .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
                                 .AddEnvironmentVariables()
                                 .Build();

                return new MongoContext(config);
            });

            services.AddScoped<IPessoaRepository>((p) =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new PessoaRepository(mongoContext, typeof(Domain.Pessoa).Name);
            });
        }
    }
}