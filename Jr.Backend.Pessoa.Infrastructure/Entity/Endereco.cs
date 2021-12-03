﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Jr.Backend.Pessoa.Infrastructure.Entity
{
    public class Endereco
    {
        public Endereco()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string Cep { get; set; }

        public string Complemento { get; set; }
    }
}