using FluentValidation;
using FluentValidation.Validators;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jr.Backend.Pessoa.Domain.Validations.Core
{
    public abstract class DocumentoGenericoValidator<T, TProperty> : PropertyValidator<T, TProperty>, IDocumentosValidator
    {
        private readonly int validLength;
        private readonly string errorMessage;

        protected abstract int[] FirstMultiplierCollection { get; }
        protected abstract int[] SecondMultiplierCollection { get; }

        protected DocumentoGenericoValidator(int validLength, string errorMessage)
        {
            this.validLength = validLength;
            this.errorMessage = errorMessage;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return string.IsNullOrWhiteSpace(errorMessage) ? base.GetDefaultMessageTemplate(errorCode) : errorMessage;
        }

        public override bool IsValid(ValidationContext<T> context, TProperty value)
        {
            var val = value as string ?? string.Empty;
            val = Regex.Replace(val, "[^a-zA-Z0-9]", "");

            if (ValidarTamanho(val) ||
                ValidarDigitosIguais(val) ||
                value == null) return false;

            var cpf = val.Select(x => (int)char.GetNumericValue(x)).ToArray();
            var digits = ObterDigito(cpf);

            return val.EndsWith(digits);
        }

        private static bool ValidarDigitosIguais(string value) => value.All(x => x == value.FirstOrDefault());

        private bool ValidarTamanho(string value) => !string.IsNullOrWhiteSpace(value) && value.Length != validLength;

        private string ObterDigito(int[] cpf)
        {
            var first = CalcularValor(FirstMultiplierCollection, cpf);
            var second = CalcularValor(SecondMultiplierCollection, cpf);

            return $"{CalcularDigito(first)}{CalcularDigito(second)}";
        }

        private static int CalcularValor(int[] weight, int[] numbers)
        {
            var sum = 0;
            for (int i = 0; i < weight.Length; i++) sum += weight[i] * numbers[i];
            return sum;
        }

        private static int CalcularDigito(int sum)
        {
            int modResult = (sum % 11);
            return modResult < 2 ? 0 : 11 - modResult;
        }
    }
}