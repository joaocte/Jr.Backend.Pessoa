using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain
{
    public class Pessoa
    {
        public NomeCompleto NomeCompleto { get; }

        public IList<Endereco> Enderecos { get; }

        public Documentos Documentos { get; }
    }
}