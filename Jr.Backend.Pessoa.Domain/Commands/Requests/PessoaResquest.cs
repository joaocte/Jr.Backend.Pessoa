using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class PessoaResquest
    {
        public NomeCompleto NomeCompleto { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public Documentos Documentos { get; set; }
    }
}