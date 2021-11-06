using Jr.Backend.Pessoa.Application.UseCases.AtualizarPessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.Handlers
{
    public class AtualizarPessoaHandler : IRequestHandler<AtualizarPessoaRequest, AtualizarPessoaResponse>
    {
        private readonly IAtualizarPessoaUseCase atualizarPessoaUseCase;

        public AtualizarPessoaHandler(IAtualizarPessoaUseCase atualizarPessoaUseCase)
        {
            this.atualizarPessoaUseCase = atualizarPessoaUseCase;
        }

        public async Task<AtualizarPessoaResponse> Handle(AtualizarPessoaRequest request, CancellationToken cancellationToken)
        {
            return await atualizarPessoaUseCase.ExecuteAsync(request);
        }
    }
}