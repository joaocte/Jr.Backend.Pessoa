using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions;
using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.DependencyInjection;
using Jr.Backend.Pessoa.Domain;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Pessoa.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrInfrastructureMongoDb(ConnectionType.ReplicaSet);

            services.AddScoped<IPessoaRepository>((p) =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new PessoaRepository(mongoContext, typeof(Domain.Pessoa).Name);
            });
        }
    }
}