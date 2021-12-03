using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.Commands.Requests
{
    public class PessoaResquest
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public IList<Endereco> Enderecos { get; set; }

        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string TituloEleitoral { get; set; }
    }
}