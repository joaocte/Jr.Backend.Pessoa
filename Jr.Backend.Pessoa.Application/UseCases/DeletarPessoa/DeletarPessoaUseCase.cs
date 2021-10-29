using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Libs.Domain.Abstractions.Interfaces.Repository;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa
{
    public class DeletarPessoaUseCase : IDeletarPessoaUseCase
    {
        private bool disposedValue;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPessoaRepository pessoaRepository;

        public DeletarPessoaUseCase(IUnitOfWork unitOfWork, IPessoaRepository pessoaRepository)
        {
            this.unitOfWork = unitOfWork;
            this.pessoaRepository = pessoaRepository;
        }

        public async Task<bool> ExecuteAsync(DeletarPessoaRequest deletarPessoaRequest)
        {
            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(deletarPessoaRequest.Id);

            if (!pessoaJaCadastrada)
                throw new NotFoundException($"Id {deletarPessoaRequest.Id} Não encontrado!");

            await pessoaRepository.RemoveAsync(deletarPessoaRequest.Id);

            return await unitOfWork.CommitAsync();
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