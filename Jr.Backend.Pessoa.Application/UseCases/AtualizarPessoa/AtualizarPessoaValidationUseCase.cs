using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Infrastructure.Interfaces;
using Jror.Backend.Libs.Domain.Abstractions.Exceptions;
using Jror.Backend.Libs.Domain.Abstractions.Notifications;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa
{
    public class AtualizarPessoaValidationUseCase : IAtualizarPessoaUseCase
    {
        private readonly IAtualizarPessoaUseCase atualizarPessoaUseCase;
        private readonly IPessoaRepository pessoaRepository;
        private readonly INotificationContext notificationContext;
        private bool disposedValue;

        public AtualizarPessoaValidationUseCase(IPessoaRepository pessoaRepository,
            IAtualizarPessoaUseCase atualizarPessoaUseCase, INotificationContext notificationContext)
        {
            this.pessoaRepository = pessoaRepository;
            this.atualizarPessoaUseCase = atualizarPessoaUseCase;
            this.notificationContext = notificationContext;
        }

        public async Task<AtualizarPessoaResponse> ExecuteAsync(AtualizarPessoaRequest atualizarPessoaRequest)
        {
            var pessoa = atualizarPessoaRequest.Convert();

            if (pessoa.Invalid)
            {
                notificationContext.AddNotifications(pessoa.ValidationResult);
                return default;
            }
            var pessoaJaCadastrada = await pessoaRepository.ExistsAsync(atualizarPessoaRequest.Cpf)
                                     && await pessoaRepository.ExistsAsync(atualizarPessoaRequest.Id);

            if (!pessoaJaCadastrada)
                throw new NotFoundException(
                    $"Cpf {atualizarPessoaRequest.Cpf} ou Id {atualizarPessoaRequest.Id} Não encontrado!");

            return await atualizarPessoaUseCase.ExecuteAsync(atualizarPessoaRequest);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    atualizarPessoaUseCase.Dispose();
                    pessoaRepository.Dispose();
                }

                disposedValue = true;
            }
        }
    }
}