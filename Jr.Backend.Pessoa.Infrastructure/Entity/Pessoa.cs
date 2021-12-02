using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jr.Backend.Pessoa.Infrastructure.Entity
{
    public class Pessoa
    {
        [Key]
        public string Id { get; set; }

        public NomeCompleto NomeCompleto { get; set; }

        public virtual IList<Endereco> Enderecos { get; set; }

        public Documentos Documentos { get; set; }
    }
}