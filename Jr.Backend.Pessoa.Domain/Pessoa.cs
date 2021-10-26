using Jr.Backend.Pessoa.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Pessoa.Domain
{
    public class Pessoa
    {
        [JsonConstructor]
        public Pessoa(NomeCompleto nomeCompleto, IList<Endereco> enderecos, Documentos documentos)
        {
            NomeCompleto = nomeCompleto;
            Enderecos = enderecos;
            Documentos = documentos;
            Id = Guid.NewGuid();
        }

        public Pessoa(Guid id, NomeCompleto nomeCompleto, IList<Endereco> enderecos, Documentos documentos)
        {
            NomeCompleto = nomeCompleto;
            Enderecos = enderecos;
            Documentos = documentos;
            Id = id;
        }

        public Guid Id { get; set; }
        public NomeCompleto NomeCompleto { get; }

        public IList<Endereco> Enderecos { get; }

        public Documentos Documentos { get; }
    }
}