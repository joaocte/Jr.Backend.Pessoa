using MediatR;
using System;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class DeletarPessoaRequest : PessoaIdRequest, IRequest<bool>
    {
        public DeletarPessoaRequest(Guid id) : base(id)
        {
        }
    }
}