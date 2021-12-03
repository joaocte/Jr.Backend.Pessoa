using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class CadastrarPessoaRequest : PessoaResquest, IRequest<CadastrarPessoaRespose>
    {
        public Pessoa Convert()
        {
            return new Pessoa(Nome, Sobrenome, Enderecos, Cpf, Rg, TituloEleitoral);
        }
    }
}