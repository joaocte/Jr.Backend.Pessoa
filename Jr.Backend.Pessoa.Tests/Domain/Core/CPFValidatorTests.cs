﻿using FluentValidation;
using FluentValidation.Results;
using Jr.Backend.Pessoa.Domain.Validations.Core;
using Jr.Backend.Pessoa.Tests.TestObjject;
using System.Linq;
using Xunit;

namespace Jr.Backend.Pessoa.Tests.Domain.Core
{
    public class CPFValidatorTests
    {
        [Fact]
        public void When_CPF_Is_Valid_Then_The_Validator_Should_Pass()
        {
            TestExtensionsValidator validator = new TestExtensionsValidator(x => x.RuleFor(r => r.Documentos.Cpf).CpfValido());
            ValidationResult result = validator.Validate(new Pessoa.Domain.Pessoa { Documentos = new("822.420.106-62") });

            Assert.True(result.IsValid);
        }

        [Fact]
        public void When_CPF_Is_Invalid_Then_Set_Custom_Message_And_Validator_Should_Fail()
        {
            const string customMessage = "Custom Message";

            TestExtensionsValidator validator = new TestExtensionsValidator(x => x.RuleFor(r => r.Documentos.Cpf).CpfValido().WithMessage(customMessage));
            ValidationResult result = validator.Validate(new Pessoa.Domain.Pessoa { Documentos = new("000.000.000-00") });

            string errorMessage = result.Errors.FirstOrDefault()?.ErrorMessage ?? string.Empty;

            Assert.False(result.IsValid);
            Assert.Equal(customMessage, errorMessage);
        }

        [Theory]
        [InlineData("144.442.344-57")]
        [InlineData("543.434.321-76")]
        [InlineData("A822.420.106-62")]
        [InlineData("822.420.106-62a")]
        public void When_CPF_Is_Invalid_Then_The_Validator_Should_Fail(string cpf)
        {
            TestExtensionsValidator validator = new TestExtensionsValidator(x => x.RuleFor(r => r.Documentos.Cpf).CpfValido());
            ValidationResult result = validator.Validate(new Pessoa.Domain.Pessoa { Documentos = new(cpf) });

            Assert.False(result.IsValid);
            Assert.Equal("O CPF é inválido!", result.Errors.First().ErrorMessage);
        }
    }
}