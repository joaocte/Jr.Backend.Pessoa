using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Pessoa.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrorInfrastructureMongoDb(ConnectionType.DirectConnection);

            services.AddScoped<IPessoaRepository>((p) =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new PessoaRepository(mongoContext, nameof(Domain.Pessoa));
            });
        }
    }
}