using Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Pessoa.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastrarPessoaUseCase, CadastrarPessoaUseCase>();
        }
    }
}