using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Infrastructure.Entity
{
    public class Pessoa
    {
        [BsonId]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public IList<Endereco> Enderecos { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string TituloEleitoral { get; set; }
    }
}