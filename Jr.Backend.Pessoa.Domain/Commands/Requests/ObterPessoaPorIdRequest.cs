using Jr.Backend.Pessoa.Domain.Commands.Responses;
using MediatR;
using System;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class ObterPessoaPorIdRequest : IRequest<ObterPessoaPorIdResponse>
    {
        public ObterPessoaPorIdRequest(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}