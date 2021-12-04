using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jr.Backend.Pessoa.Infrastructure.Entity
{
    public class Pessoa
    {
        [Key]
        public Guid Id { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string TituloEleitoral { get; set; }
    }
}