using MediatR;
using System;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class DeletarPessoaRequest : PessoaIdRequest, IRequest
    {
        public DeletarPessoaRequest(Guid id) : base(id)
        {
        }
    }
}