using Jr.Backend.Pessoa.Application.UseCases.ObterPessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.Handlers
{
    public class ObterPessoaPorIdHandler : IRequestHandler<ObterPessoaPorIdRequest, ObterPessoaPorIdResponse>
    {
        private readonly IObterPessoaPorIdUseCase obterPessoaPorIdUseCase;

        public ObterPessoaPorIdHandler(IObterPessoaPorIdUseCase obterPessoaPorIdUseCase)
        {
            this.obterPessoaPorIdUseCase = obterPessoaPorIdUseCase;
        }

        public async Task<ObterPessoaPorIdResponse> Handle(ObterPessoaPorIdRequest request, CancellationToken cancellationToken)
        {
            return await obterPessoaPorIdUseCase.ExecuteAsync(request);
        }
    }
}