using Jr.Backend.Pessoa.Application.UseCases.DeletarPessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.Handlers
{
    public class DeletarPessoaHandler : IRequestHandler<DeletarPessoaRequest, bool>
    {
        private readonly IDeletarPessoaUseCase deletarPessoaUseCase;

        public DeletarPessoaHandler(IDeletarPessoaUseCase deletarPessoaUseCase)
        {
            this.deletarPessoaUseCase = deletarPessoaUseCase;
        }

        public Task<bool> Handle(DeletarPessoaRequest request, CancellationToken cancellationToken)
        {
            return deletarPessoaUseCase.ExecuteAsync(request);
        }
    }
}