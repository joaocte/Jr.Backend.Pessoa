using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Message.Events.Pessoa.Events;
using MassTransit;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa
{
    public class DeletarPessoaUseCase : IDeletarPessoaUseCase
    {
        private bool disposedValue;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IBus bus;
        private readonly IMapper mapper;

        public DeletarPessoaUseCase(IPessoaRepository pessoaRepository, IBus bus, IMapper mapper)
        {
            this.pessoaRepository = pessoaRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        public async Task<Unit> ExecuteAsync(DeletarPessoaRequest deletarPessoaRequest, CancellationToken cancellationToken = default)
        {
            var pessoa = await pessoaRepository.GetByIdAsync(deletarPessoaRequest.Id);

            await pessoaRepository.RemoveAsync(deletarPessoaRequest.Id);

            var @event = mapper.Map<PessoaDeletadaEvent>(pessoa);

            await bus.Publish(@event);
            return Unit.Value;
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