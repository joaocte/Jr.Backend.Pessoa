using FluentValidation;

namespace Jr.Backend.Pessoa.Domain.Validations.Core
{
    public static partial class DocumentoExtensionsValidation
    {
        public static IRuleBuilderOptions<T, string> CpfValido<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CPFValidator<T, string>());
        }
    }
}