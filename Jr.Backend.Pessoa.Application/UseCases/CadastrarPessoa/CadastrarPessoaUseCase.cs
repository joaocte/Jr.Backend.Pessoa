using AutoMapper;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Libs.Utilities;
using Jr.Backend.Message.Events.Pessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Domain.Excepitons;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using MassTransit;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IPessoaRepository pessoaRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IBus bus;
        private Uri uriQueue;

        public CadastrarPessoaUseCase(IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork, IMapper mapper, IBus bus, IConfiguration configuration)
        {
            this.pessoaRepository = pessoaRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.bus = bus;
            uriQueue = new($"{configuration["RabbitSetting:UriBase"]}/{typeof(PessoaCadastradaEvent).Name}");
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            Domain.Pessoa pessoa = cadastrarPessoaRequest.Convert();

            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(pessoa.Documentos.Cpf);

            if (pessoaJaCadastrada)
                throw new PessoaJaCadastradaException($"Cpf {pessoa.Documentos.Cpf} Já cadastrado!");

            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(pessoa);

            PessoaCadastradaEvent @event = mapper.Map<PessoaCadastradaEvent>(pessoaEntity);

            await pessoaRepository.AddAsync(pessoaEntity);

            await unitOfWork.CommitAsync();

            var endpoint = await bus.GetSendEndpoint(uriQueue);

            await endpoint.Send(@event);
            return new CadastrarPessoaRespose
            {
                Id = pessoaEntity.Id.ToGuid()
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    pessoaRepository?.Dispose();
                    unitOfWork?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
        }
    }
}