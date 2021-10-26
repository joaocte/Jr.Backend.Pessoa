using System;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class PessoaIdRequest
    {
        public PessoaIdRequest(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; set; }
    }
}