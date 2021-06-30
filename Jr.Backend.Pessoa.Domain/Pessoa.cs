using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain
{
    public class Pessoa
    {
        public NomeCompleto NomeCompleto { get; private set; }

        public IList<Endereco> Enderecos { get; private set; }

        public Documentos Documentos { get; set; }
    }
}