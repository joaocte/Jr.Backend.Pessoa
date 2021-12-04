using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Message.Events.Pessoa.Events;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IPessoaRepository pessoaRepository;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public CadastrarPessoaUseCase(IPessoaRepository pessoaRepository, IMapper mapper, IBus bus)
        {
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            Domain.Pessoa pessoa = cadastrarPessoaRequest.Convert();

            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(pessoa);

            await pessoaRepository.AddAsync(pessoaEntity);

            PessoaCadastradaEvent @event = mapper.Map<PessoaCadastradaEvent>(pessoaEntity);

            await bus.Publish(@event);
            return new CadastrarPessoaRespose
            {
                Id = pessoaEntity.Id
            };
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    pessoaRepository?.Dispose();
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