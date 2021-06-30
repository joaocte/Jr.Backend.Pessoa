using Jr.Backend.Pessoa.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jr.Backend.Pessoa.Tests.Domain.ValueObject
{
    public class NomeCompletoTests
    {
        [Theory]
        [InlineData("Felipe", "Michele")]
        [InlineData("Paola", "Leandro")]
        public void DeveInstanciarUmNomeCompletoEValidarSeOsNomeSaoDiferentes(string value1, string value2)
        {
            NomeCompleto nomeCompleto1 = new(value1);
            NomeCompleto nomeCompleto2 = new(value2);

            Assert.False(nomeCompleto1.Equals(nomeCompleto2));
            Assert.False(nomeCompleto2.Equals(nomeCompleto1));
        }

        [Theory]
        [InlineData("Felipe", "Felipe")]
        [InlineData("Paola", "Paola")]
        public void DeveInstanciarUmNomeCompletoEValidarSeOsNomeSaoIguais(string value1, string value2)
        {
            NomeCompleto nomeCompleto1 = new(value1);
            NomeCompleto nomeCompleto2 = new(value2);

            Assert.True(nomeCompleto1.Equals(nomeCompleto2));
            Assert.True(nomeCompleto2.Equals(nomeCompleto1));
        }

        [Theory]
        [InlineData("Felipe", "Felipe")]
        [InlineData("Paola", "Paola")]
        public void DeveInstanciarUmNomeCompletoDeFormaImplicitaEValidarSeOsNomeSaoIguais(string value1, string value2)
        {
            NomeCompleto nomeCompleto1 = value1;
            NomeCompleto nomeCompleto2 = value2;

            Assert.True(nomeCompleto1.Equals(nomeCompleto2));
            Assert.True(nomeCompleto2.Equals(nomeCompleto1));
        }

        [Theory]
        [InlineData("Felipe", "Breder")]
        [InlineData("Joao", "Rego")]
        public void DeveInstanciarUmNomeCompletoComNomeESobrenome(string nome, string sobrenome)
        {
            NomeCompleto nomeCompleto1 = new(nome, sobrenome);

            Assert.IsType<NomeCompleto>(nomeCompleto1);
            Assert.NotNull(nomeCompleto1);
            Assert.NotEmpty(nomeCompleto1.Nome);
            Assert.NotEmpty(nomeCompleto1.Sobrenome);
            Assert.Equal(nome, nomeCompleto1.Nome);
            Assert.Equal(sobrenome, nomeCompleto1.Sobrenome);
        }
    }
}