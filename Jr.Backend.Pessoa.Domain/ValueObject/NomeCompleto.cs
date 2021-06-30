﻿using Jr.Backend.Libs.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.ValueObject
{
    public class NomeCompleto : GenericValueObject
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }

        public NomeCompleto(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public NomeCompleto(string nome)
        {
            Nome = nome;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Nome;
            yield return Sobrenome;
        }

        public static implicit operator NomeCompleto(string nomeCompleto) => new(nomeCompleto);

        public static implicit operator string(NomeCompleto nomeCompleto) => nomeCompleto;
    }
}