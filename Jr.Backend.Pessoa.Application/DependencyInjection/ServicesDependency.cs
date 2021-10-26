using AutoMapper;
using MediatR;
using Jr.Backend.Pessoa.Application.AutoMapper;
using Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.ObterPessoa;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Jr.Backend.Pessoa.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services)
        {
            services.AddScoped<ICadastrarPessoaUseCase, CadastrarPessoaUseCase>();
            services.AddScoped<IObterPessoaPorIdUseCase, ObterPessoaPorIdUseCase>();
            services.AddScoped<IAtualizarPessoaUseCase, AtualizarPessoaUseCase>();
            services.AddScoped<IDeletarPessoaUseCase, DeletarPessoaUseCase>();
            services.AddMediatR(Assembly.GetExecutingAssembly());
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