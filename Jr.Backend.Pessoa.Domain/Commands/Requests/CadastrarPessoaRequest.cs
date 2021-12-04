using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class CadastrarPessoaRequest : PessoaResquest, IRequest<CadastrarPessoaRespose>
    {
    }
}