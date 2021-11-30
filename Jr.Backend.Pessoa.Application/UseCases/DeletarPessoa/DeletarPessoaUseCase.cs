using AutoMapper;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.Data.Shared.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa
{
    public class DeletarPessoaUseCase : IDeletarPessoaUseCase
    {
        private bool disposedValue;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IBus bus;
        private readonly IMapper mapper;

        public DeletarPessoaUseCase(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository, IBus bus, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.pessoaRepository = pessoaRepository;
            this.bus = bus;
            this.mapper = mapper;
        }

        public async Task<bool> ExecuteAsync(DeletarPessoaRequest deletarPessoaRequest)
        {
            var pessoa = await pessoaRepository.GetByIdAsync(deletarPessoaRequest.Id);

            await pessoaRepository.RemoveAsync(deletarPessoaRequest.Id);

            var commit = await unitOfWork.CommitAsync();

            //var @event = mapper.Map<PessoaDeletadaEvent>(pessoa);

            //await bus.Publish(@event);

            return commit;
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