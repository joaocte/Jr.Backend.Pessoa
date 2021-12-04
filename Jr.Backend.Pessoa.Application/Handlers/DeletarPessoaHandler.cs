using Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.Handlers
{
    public class DeletarPessoaHandler : IRequestHandler<DeletarPessoaRequest>
    {
        private readonly IDeletarPessoaUseCase deletarPessoaUseCase;

        public DeletarPessoaHandler(IDeletarPessoaUseCase deletarPessoaUseCase)
        {
            this.deletarPessoaUseCase = deletarPessoaUseCase;
        }

        public async Task<Unit> Handle(DeletarPessoaRequest request, CancellationToken cancellationToken)
        {
            return await deletarPessoaUseCase.ExecuteAsync(request, cancellationToken);
        }
    }
}