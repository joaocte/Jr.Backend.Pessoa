using AutoMapper;
using Jr.Backend.Pessoa.Application.AutoMapper;
using Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa;
using Jr.Backend.Pessoa.Application.UseCases.ObterPessoa;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Jr.Backend.Pessoa.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICadastrarPessoaUseCase, CadastrarPessoaUseCase>();
            services.Decorate<ICadastrarPessoaUseCase, CadastrarPessoaValidationUseCase>();

            services.AddScoped<IObterPessoaUseCase, ObterPessoaUseCase>();

            services.AddScoped<IAtualizarPessoaUseCase, AtualizarPessoaUseCase>();
            services.Decorate<IAtualizarPessoaUseCase, AtualizarPessoaValidationUseCase>();

            services.AddScoped<IDeletarPessoaUseCase, DeletarPessoaUseCase>();
            services.Decorate<IDeletarPessoaUseCase, DeletarPessoaValidationUseCase>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                    {
                        var uri = configuration["RabbitSetting:UriBase"];
                        var user = configuration["RabbitSetting:User"];
                        var password = configuration["RabbitSetting:Password"];
                        config.Host(new Uri(uri), h =>
                        {
                            h.Username(user);
                            h.Password(password);
                        });
                    }
                ));
            });

            services.AddMassTransitHostedService();
        }
    }
}