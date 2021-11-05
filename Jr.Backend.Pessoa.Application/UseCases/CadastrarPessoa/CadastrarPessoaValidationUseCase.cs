using Jr.Backend.Libs.Domain.Abstractions.Exceptions;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using System;
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
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CadastrarPessoaValidationUseCase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}