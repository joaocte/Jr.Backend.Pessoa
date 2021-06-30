using FluentValidation;
using System;

namespace Jr.Backend.Pessoa.Tests.TestObjject
{
    public class TestExtensionsValidator : InlineValidator<Pessoa.Domain.Pessoa>
    {
        public TestExtensionsValidator()
        { }

        public TestExtensionsValidator(params Action<TestExtensionsValidator>[] actionList)
        {
            foreach (var action in actionList) action.Invoke(this);
        }
    }
}