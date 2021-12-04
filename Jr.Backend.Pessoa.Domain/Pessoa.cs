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
        public Pessoa(string nome, string sobrenome, IList<Endereco> enderecos, string cpf, string rg, string tituloEleitoral)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Enderecos = enderecos;
            Cpf = cpf;
            Rg = rg;
            TituloEleitoral = tituloEleitoral;
            Id = Guid.NewGuid();
            Validate(this, new PessoaValidation());
        }

        public Pessoa(Guid id, string nome, string sobrenome, IList<Endereco> enderecos, string cpf, string rg, string tituloEleitoral) : this(nome, sobrenome, enderecos, cpf, rg, tituloEleitoral)
        {
            Id = id;
        }

        public string Nome { get; }

        public string Sobrenome { get; }

        public IList<Endereco> Enderecos { get; }

        public string Cpf { get; }
        public string Rg { get; }
        public string TituloEleitoral { get; }
    }
}