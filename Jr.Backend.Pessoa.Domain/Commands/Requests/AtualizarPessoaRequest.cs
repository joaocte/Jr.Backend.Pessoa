using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using System;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class AtualizarPessoaRequest : PessoaResquest, IRequest<AtualizarPessoaResponse>
    {
        public Guid Id { get; set; }

        public Pessoa Convert()
        {
            return new Pessoa(Id, NomeCompleto, Enderecos, Documentos);
        }
    }
}