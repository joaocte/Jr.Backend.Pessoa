using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa
{
    public class DeletarPessoaValidationUseCase : IDeletarPessoaUseCase
    {
        private bool disposedValue;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IDeletarPessoaUseCase deletarPessoaUseCase;

        public DeletarPessoaValidationUseCase(IPessoaRepository pessoaRepository, IDeletarPessoaUseCase deletarPessoaUseCase)

        {
            this.pessoaRepository = pessoaRepository;
            this.deletarPessoaUseCase = deletarPessoaUseCase;
        }

        public async Task<bool> ExecuteAsync(DeletarPessoaRequest deletarPessoaRequest)
        {
            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(deletarPessoaRequest.Id);

            if (!pessoaJaCadastrada)
                throw new NotFoundException($"Id {deletarPessoaRequest.Id} Não encontrado!");

            return await deletarPessoaUseCase.ExecuteAsync(deletarPessoaRequest);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    deletarPessoaUseCase.Dispose();
                    pessoaRepository.Dispose();
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