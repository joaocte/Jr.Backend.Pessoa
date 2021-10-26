using Jr.Backend.Pessoa.Application.UseCases.CadastrarPessoa;
using Jr.Backend.Pessoa.Domain.Commands.Requests;
using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Pessoa.Application.Handlers
{
    public class CadastrarPessoaHandler : IRequestHandler<CadastrarPessoaRequest, CadastrarPessoaRespose>
    {
        private ICadastrarPessoaUseCase cadastrarPessoaUseCase;

        public CadastrarPessoaHandler(ICadastrarPessoaUseCase cadastrarPessoaUseCase)
        {
            this.cadastrarPessoaUseCase = cadastrarPessoaUseCase;
        }

        public async Task<CadastrarPessoaRespose> Handle(CadastrarPessoaRequest request, CancellationToken cancellationToken)
        {
            return await cadastrarPessoaUseCase.ExecuteAsync(request);
        }
    }
}