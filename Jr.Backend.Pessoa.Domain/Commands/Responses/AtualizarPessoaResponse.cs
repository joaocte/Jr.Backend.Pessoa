using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Pessoa.Domain.Commands.Responses
{
    public class AtualizarPessoaResponse : Pessoa
    {
        [JsonConstructor]
        public AtualizarPessoaResponse(string nome, string sobrenome, IList<Endereco> enderecos, string cpf, string rg, string tituloEleitoral) : base(nome, sobrenome, enderecos, cpf, rg, tituloEleitoral)
        {
        }
    }
}