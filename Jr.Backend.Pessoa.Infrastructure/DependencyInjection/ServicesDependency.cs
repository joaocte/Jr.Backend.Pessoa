using Jr.Backend.Libs.Infrastructure.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.DependencyInjection;
using Jr.Backend.Pessoa.Domain;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace Jr.Backend.Pessoa.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrInfrastructure();
            services.AddScoped<IPessoaRepository>((p) =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new PessoaRepository(mongoContext, typeof(Domain.Pessoa).Name);
            });
        }
    }
}