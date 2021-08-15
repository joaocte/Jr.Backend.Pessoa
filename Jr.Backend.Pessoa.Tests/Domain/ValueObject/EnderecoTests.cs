using Jr.Backend.Pessoa.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jr.Backend.Pessoa.Tests.Domain.ValueObject
{
    public class EnderecoTests
    {
        [Fact]
        public void DeveInstanciarEnderecoEValidarSeOsEnderecosSaoDiferentes()
        {
            Endereco endereco1 = new("logradouro", "bairro", "numero", "estado", "cidade", "pais", "cep");
            Endereco endereco2 = new("logradouro", "bairro_2", "numero", "estado", "cidade", "pais", "cep");

            Assert.False(endereco1.Equals(endereco2));
            Assert.False(endereco2.Equals(endereco1));
        }

        [Fact]
        public void DeveInstanciarEnderecoEValidarSeOsEnderecosSaoIguais()
        {
            Endereco endereco1 = new("logradouro", "bairro", "numero", "estado", "cidade", "pais", "cep");
            Endereco endereco2 = new("logradouro", "bairro", "numero", "estado", "cidade", "pais", "cep");

            Assert.True(endereco1.Equals(endereco2));
            Assert.True(endereco2.Equals(endereco1));
        }

        [Fact]
        public void DeveConverterEnderecoDeFormaImplicita()
        {
            Endereco endereco1 = new("logradouro", "bairro", "numero", "estado", "cidade", "pais", "cep");
            string endereco = endereco1;

            Assert.Equal(endereco, endereco1);
        }
    }
}