using Jr.Backend.Pessoa.Domain.ValueObject;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Pessoa.Domain.Commands.Responses
{
    public class ObterPessoaPorIdResponse : Pessoa
    {
        [JsonConstructor]
        public ObterPessoaPorIdResponse(NomeCompleto nomeCompleto, IList<Endereco> enderecos, Documentos documentos) : base(nomeCompleto, enderecos, documentos)
        {
        }
    }
}