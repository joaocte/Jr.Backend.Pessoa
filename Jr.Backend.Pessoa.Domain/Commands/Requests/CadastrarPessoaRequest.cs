using Jr.Backend.Pessoa.Domain.Commands.Responses;
using Jr.Backend.Pessoa.Domain.ValueObject;
using MediatR;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class CadastrarPessoaRequest : IRequest<CadastrarPessoaRespose>
    {
        public NomeCompleto NomeCompleto { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public Documentos Documentos { get; set; }

        public Pessoa Convert()
        {
            return new Pessoa(NomeCompleto, Enderecos, Documentos);
        }
    }
}