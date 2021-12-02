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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<DbContext, ApplicationDbContext>();
            services.AddServiceDependencyJrorInfrastructureEntityFramework();

            services.AddScoped<IPessoaRepository>(x => new PessoaRepository(x.GetService<ApplicationDbContext>()));
        }
    }
}