using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jr.Backend.Pessoa.Infrastructure.Repository.MongoDb;
using Jror.Backend.Libs.Infrastructure.EntityFramework.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Pessoa.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddServiceDependencyJrorInfrastructureEntityFramework();

            services.AddScoped<IPessoaRepository>(x => new PessoaRepository(x.GetService<ApplicationDbContext>()));
            services.AddScoped<IEnderecoRepository>(x => new EnderecoRepository(x.GetService<ApplicationDbContext>()));
        }
    }
}