using AutoMapper;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa
{
    public class AtualizarPessoaUseCase : IAtualizarPessoaUseCase
    {
        private bool disposedValue;

        private readonly IUnitOfWork unitOfWork;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IMapper mapper;
        private readonly IBus bus;

        public AtualizarPessoaUseCase(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository, IMapper mapper, IBus bus)
        {
            this.unitOfWork = unitOfWork;
            this.pessoaRepository = pessoaRepository;
            this.mapper = mapper;
            this.bus = bus;
        }

        public async Task<AtualizarPessoaResponse> ExecuteAsync(AtualizarPessoaRequest atualizarPessoaRequest)
        {
            var pessoaEntity = mapper.Map<Infrastructure.Entity.Pessoa>(atualizarPessoaRequest);

            await pessoaRepository.UpdateAsync(pessoaEntity);

            await unitOfWork.CommitAsync();

            //PessoaAtualizadaEvent @event = mapper.Map<PessoaAtualizadaEvent>(pessoaEntity);

            //await bus.Publish(@event);

            var pessoa = mapper.Map<Domain.Pessoa>(pessoaEntity);

            return new AtualizarPessoaResponse(pessoa.NomeCompleto, pessoa.Enderecos, pessoa.Documentos);
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

        void System.IDisposable.Dispose()
        {
            Dispose(disposing: true);
        }
    }
}