using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using System;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class ObterPessoaPorIdRequest : PessoaIdRequest, IRequest<ObterPessoaPorIdResponse>
    {
        public ObterPessoaPorIdRequest(Guid id) : base(id)
        {
        }
    }
}