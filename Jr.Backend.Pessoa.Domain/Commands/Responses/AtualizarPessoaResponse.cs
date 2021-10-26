using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Pessoa.Domain.Commands.Responses
{
    public class AtualizarPessoaResponse : Pessoa
    {
        [JsonConstructor]
        public AtualizarPessoaResponse(NomeCompleto nomeCompleto, IList<Endereco> enderecos, Documentos documentos) : base(nomeCompleto, enderecos, documentos)
        {
        }
    }
}