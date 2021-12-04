using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Message.Events.Pessoa.Events;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa
{
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IPessoaRepository pessoaRepository;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public AtualizarPessoaUseCase(IPessoaRepository pessoaRepository, IMapper mapper, IBus bus)
        {
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<AtualizarPessoaResponse> ExecuteAsync(AtualizarPessoaRequest atualizarPessoaRequest)
        {
            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(atualizarPessoaRequest);

            await pessoaRepository.UpdateAsync(pessoaEntity);

            PessoaAtualizadaEvent @event = mapper.Map<PessoaAtualizadaEvent>(pessoaEntity);

            await bus.Publish(@event);

            var pessoa = mapper.Map<Domain.Pessoa>(pessoaEntity);

            return new AtualizarPessoaResponse(pessoa.Nome, pessoa.Sobrenome, pessoa.Enderecos, pessoa.Cpf, pessoa.Rg, pessoa.TituloEleitoral);
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

        void System.IDisposable.Dispose()
        {
            Dispose(disposing: true);
        }
    }
}