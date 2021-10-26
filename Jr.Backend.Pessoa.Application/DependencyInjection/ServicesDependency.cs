using AutoMapper;
using Jr.Backend.Pessoa.Application.AutoMapper;
using Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.ObterPessoa;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Pessoa.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastrarPessoaUseCase, CadastrarPessoaUseCase>();
            services.AddScoped<IObterPessoaPorIdUseCase, ObterPessoaPorIdUseCase>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}