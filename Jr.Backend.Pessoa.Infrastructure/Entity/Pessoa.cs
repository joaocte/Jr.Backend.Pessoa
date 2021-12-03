using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jr.Backend.Pessoa.Infrastructure.Entity
{
    public sealed class Pessoa
    {
        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }

        [Key]
        public string Id { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string TituloEleitoral { get; set; }
    }
}