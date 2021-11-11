using Jr.Backend.Libs.Domain.Abstractions;
using Jr.Backend.Pessoa.Domain.Validations;
using Jr.Backend.Pessoa.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Pessoa.Domain
{
    public class Pessoa : Entity
    {
        [JsonConstructor]
        public Pessoa(NomeCompleto nomeCompleto, IList<Endereco> enderecos, Documentos documentos)
        {
            NomeCompleto = nomeCompleto;
            Enderecos = enderecos;
            Documentos = documentos;

            this.Validate(this, new PessoaValidation());
        }

        public Pessoa(Guid id, NomeCompleto nomeCompleto, IList<Endereco> enderecos, Documentos documentos) : this(nomeCompleto, enderecos, documentos)
        {
            Id = id;
        }

        public NomeCompleto NomeCompleto { get; }

        public IList<Endereco> Enderecos { get; }

        public Documentos Documentos { get; }
    }
}