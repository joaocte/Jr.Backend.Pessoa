using Jr.Backend.Pessoa.Application.UseCases.ObterPessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.Handlers
{
    public class ObterPessoaPorIdHandler : IRequestHandler<ObterPessoaPorIdRequest, IEnumerable<Domain.Pessoa>>
    {
        private readonly IObterPessoaUseCase obterPessoaPorIdUseCase;

        public ObterPessoaPorIdHandler(IObterPessoaUseCase obterPessoaPorIdUseCase)
        {
            this.obterPessoaPorIdUseCase = obterPessoaPorIdUseCase;
        }

        public async Task<IEnumerable<Domain.Pessoa>> Handle(ObterPessoaPorIdRequest request, CancellationToken cancellationToken)
        {
            return await obterPessoaPorIdUseCase.ExecuteAsync(request);
        }
    }
}