using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa
{
    public class AtualizarPessoaValidationUseCase : IAtualizarPessoaUseCase
    {
        private bool disposedValue;
        private readonly IPessoaRepository pessoaRepository;
        private readonly IAtualizarPessoaUseCase atualizarPessoaUseCase;

        public AtualizarPessoaValidationUseCase(IPessoaRepository pessoaRepository, IAtualizarPessoaUseCase atualizarPessoaUseCase)
        {
            this.pessoaRepository = pessoaRepository;
            this.atualizarPessoaUseCase = atualizarPessoaUseCase;
        }

        public async Task<AtualizarPessoaResponse> ExecuteAsync(AtualizarPessoaRequest atualizarPessoaRequest)
        {
            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(atualizarPessoaRequest.Documentos.Cpf)
               && await pessoaRepository.ExistsAsync(atualizarPessoaRequest.Id);

            if (!pessoaJaCadastrada)
                throw new NotFoundException($"Cpf {atualizarPessoaRequest.Documentos.Cpf} ou Id {atualizarPessoaRequest.Id} Não encontrado!");

            return await atualizarPessoaUseCase.ExecuteAsync(atualizarPessoaRequest);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
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