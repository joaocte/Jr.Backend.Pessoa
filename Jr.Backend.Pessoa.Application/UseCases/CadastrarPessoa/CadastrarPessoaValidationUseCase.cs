using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaValidationUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;
        private readonly ICadastrarPessoaUseCase cadastrarPessoaUseCase;
        private readonly IPessoaRepository pessoaRepository;

        public CadastrarPessoaValidationUseCase(ICadastrarPessoaUseCase cadastrarPessoaUseCase, IPessoaRepository pessoaRepository)
        {
            this.cadastrarPessoaUseCase = cadastrarPessoaUseCase;
            this.pessoaRepository = pessoaRepository;
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(cadastrarPessoaRequest.Documentos.Cpf);

            if (pessoaJaCadastrada)
                throw new AlreadyRegisteredException($"Cpf {cadastrarPessoaRequest.Documentos.Cpf} Já cadastrado!");
            return await cadastrarPessoaUseCase.ExecuteAsync(cadastrarPessoaRequest);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    cadastrarPessoaUseCase.Dispose();
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