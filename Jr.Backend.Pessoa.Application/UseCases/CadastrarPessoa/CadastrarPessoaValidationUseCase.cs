using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Domain.Abstractions.Exceptions;
using Jror.Backend.Libs.Domain.Abstractions.Notifications;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa
{
    public class CadastrarPessoaValidationUseCase : ICadastrarPessoaUseCase
    {
        private bool disposedValue;
        private readonly ICadastrarPessoaUseCase cadastrarPessoaUseCase;
        private readonly IPessoaRepository pessoaRepository;
        private readonly INotificationContext notificationContext;

        public CadastrarPessoaValidationUseCase(ICadastrarPessoaUseCase cadastrarPessoaUseCase, IPessoaRepository pessoaRepository, INotificationContext notificationContext)
        {
            this.cadastrarPessoaUseCase = cadastrarPessoaUseCase;
            this.pessoaRepository = pessoaRepository;
            this.notificationContext = notificationContext;
        }

        public async Task<CadastrarPessoaRespose> ExecuteAsync(CadastrarPessoaRequest cadastrarPessoaRequest)
        {
            var pessoa = cadastrarPessoaRequest.Convert();

            if (pessoa.Invalid)
            {
                notificationContext.AddNotifications(pessoa.ValidationResult);
                return default;
            }

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