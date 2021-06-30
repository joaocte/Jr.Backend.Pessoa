﻿using Jr.Backend.Libs.Domain.ValueObject;
using System.Collections.Generic;

namespace Jr.Backend.Pessoa.Domain.ValueObject
{
    public class Documentos : GenericValueObject
    {
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public string TituloEleitoral { get; set; }

        public Documentos(string cpf, string rg, string tituloEleitoral)
        {
            Cpf = cpf;
            Rg = rg;
            TituloEleitoral = tituloEleitoral;
        }

        public Documentos(string cpf)
        {
            Cpf = cpf;
        }

        public Documentos(string cpf, string rg) : this(cpf)
        {
            Rg = rg;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Cpf;
            yield return Rg;
            yield return TituloEleitoral;
        }
    }
}